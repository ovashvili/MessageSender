using System.Text.Json;
using MessageSender.Application.Common.Models;
using MessageSender.Application.Sms.Contracts;
using MessageSender.Application.Sms.Models;
using MessageSender.Domain.Enums;
using Microsoft.Extensions.Logging;
using StatusCodes = MessageSender.Application.Common.Enums.StatusCodes;

namespace MessageSender.Application.Sms.Services;

public class SmsService : ISmsService
{
    private readonly ISmsServiceRepositoryFacade _smsServiceRepositoryFacade;
    private readonly ISmsIntegrationFactory _smsIntegrationFactory;
    private readonly IFireForgetSmsRepositoryHandler _fireForgetSmsRepositoryHandler;
    private readonly ILogger<SmsService> _logger;

    public SmsService(ISmsServiceRepositoryFacade smsServiceRepositoryFacade,
        ISmsIntegrationFactory smsIntegrationFactory,
        IFireForgetSmsRepositoryHandler fireForgetSmsRepositoryHandler,
        ILogger<SmsService> logger)
    {
        _smsServiceRepositoryFacade = smsServiceRepositoryFacade;
        _smsIntegrationFactory = smsIntegrationFactory;
        _fireForgetSmsRepositoryHandler = fireForgetSmsRepositoryHandler;
        _logger = logger;
    }

    public Task<Result<long>> SendAsync(SendSmsDto dto, Guid clientId, CancellationToken cancellationToken = default)
    {
        return SendWithCountryCodeAsync(dto.To, dto.CountryCode, dto.Content, clientId, dto.Provider, cancellationToken);
    }

    public async Task<Result<MessageDeliveryStatus?>> GetStatusAsync(long id, CancellationToken cancellationToken = default)
    {
        try
        {
            return new Result<MessageDeliveryStatus?>(StatusCodes.Success, "Success",
                await _smsServiceRepositoryFacade.GetSmsStatusAsync(id, cancellationToken));
        }
        catch (InvalidOperationException e)
        {
            if (_logger.IsEnabled(LogLevel.Critical))
                _logger.LogCritical(e, e.Message);

            return new Result<MessageDeliveryStatus?>(StatusCodes.GenericFailedError, e.Message);
        }
        catch (Exception e)
        {
            if (_logger.IsEnabled(LogLevel.Critical))
                _logger.LogCritical(e, e.Message);

            return new Result<MessageDeliveryStatus?>(StatusCodes.GenericFailedError,
                "An unknown error has occurred, please contact the system administrator.");
        }
    }

    private async Task<Result<long>> SendWithCountryCodeAsync(string number, string countryCode, string content,
        Guid clientId, string? provider = null, CancellationToken cancellationToken = default)
    {
        var smsId = await _smsServiceRepositoryFacade.InsertSmsAsync(clientId, number, cancellationToken);

        _fireForgetSmsRepositoryHandler.Execute(smsId, content, cancellationToken);

        var clientInfo = await GetClientInfo(clientId, cancellationToken);

        var greyListCheckResult = await CheckGreyListAsync(smsId, number, cancellationToken);
        if (greyListCheckResult != null) return greyListCheckResult;

        var countryCheckResult = await CheckCountryAsync(smsId, countryCode, cancellationToken);
        if (countryCheckResult != null) return countryCheckResult;

        // Check forced provider
        if (provider is not null)
        {
            var forcedProvider = await _smsServiceRepositoryFacade.GetProviderAsync(provider, cancellationToken);
            return await TrySendSmsAsync(smsId,clientInfo.SmsFrom, forcedProvider?.ProviderId ?? -1, number, content, cancellationToken);
        }

        // Get country providers by priority
        var countryProviderIds =
            (await _smsServiceRepositoryFacade.GetCountryProvidersOrderedByPriorityAsync(countryCode, cancellationToken))
            .Select(cp => cp.Provider.ProviderId).ToList();
        
        var countryProvidersResult =
            await TrySendWithProvidersAsync(countryProviderIds, smsId, clientInfo.SmsFrom, number, content, cancellationToken);
        
        if (countryProvidersResult != null)
            return countryProvidersResult;

        // get global providers by priority
        var globalProviders =
            await _smsServiceRepositoryFacade.GetGlobalProvidersOrderedByPriorityAsync(cancellationToken);

        // Exclude country providers from the global providers
        var excludedGlobalProviderIds = globalProviders
            .Where(gp => !countryProviderIds.Any(cp => cp == gp.ProviderId))
            .Select(gp => gp.ProviderId);

        var globalProvidersResult = await TrySendWithProvidersAsync(
            excludedGlobalProviderIds,
            smsId, clientInfo.SmsFrom, number, content, cancellationToken);
        
        if (globalProvidersResult != null)
            return globalProvidersResult;

        return new Result<long>(StatusCodes.GenericFailedError, "Failed to send Sms");
    }

    private async Task<SmsConfig> GetClientInfo(Guid clientId, CancellationToken cancellationToken)
    {
        var client = await _smsServiceRepositoryFacade.GetClientAsync(clientId, cancellationToken);

        if (client == null || string.IsNullOrEmpty(client.Config))
            throw new InvalidOperationException("Client or configuration is missing.");

        return JsonSerializer.Deserialize<SmsConfig>(client.Config)!;
    }

    private async Task<Result<long>?> TrySendWithProvidersAsync(IEnumerable<int> providersIds, long smsId, string from, string number,
        string content, CancellationToken cancellationToken)
    {
        foreach (var providerId in providersIds)
        {
            var sendResult = await TrySendSmsAsync(smsId, from, providerId, number, content, cancellationToken);
            if (sendResult.StatusCode == StatusCodes.Success)
                return sendResult;
        }
        return null;
    }

    private async Task<Result<long>?> CheckGreyListAsync(long smsId, string number, CancellationToken cancellationToken)
    {
        var greyListContact = await _smsServiceRepositoryFacade.GetGreyListContactAsync(number, cancellationToken);

        if (greyListContact is not { Status: ContactStatus.Black })
            return null;

        var messageDeliveryId = await _smsServiceRepositoryFacade.InsertMessageDeliveryAsync(smsId,
            MessageDeliveryStatus.Fail,null,"phone number blacklisted",cancellationToken);
        
        return new Result<long>(StatusCodes.GenericFailedError, "user is blacklisted", messageDeliveryId);
    }

    private async Task<Result<long>?> CheckCountryAsync(long smsId, string countryCode, CancellationToken cancellationToken)
    {
        var country = await _smsServiceRepositoryFacade.GetCountryAsync(countryCode, cancellationToken);

        if (country is not null)
            return null;

        var messageDeliveryId = await _smsServiceRepositoryFacade.InsertMessageDeliveryAsync(smsId,
            MessageDeliveryStatus.Fail,null,"country blocked",cancellationToken);
        
        return new Result<long>(StatusCodes.NotFound, "country blocked", messageDeliveryId);
    }

    private async Task<Result<long>> TrySendSmsAsync(long smsId, string from, int providerId, string number, string content, CancellationToken cancellationToken = default)
    {
        var providerIntegration = _smsIntegrationFactory.Create(providerId);

        if (providerIntegration is null)
            return new Result<long>(StatusCodes.NotFound, "provider not found");

        var messageDeliveryId = await _smsServiceRepositoryFacade.InsertMessageDeliveryAsync(smsId,
            MessageDeliveryStatus.SendingToProvider, providerIntegration.ProviderId, null, cancellationToken);

        var smsSendResult = await providerIntegration.SendAsync(from, number, content, cancellationToken);
        
        if (smsSendResult.ErrorMessage is not null)
        {
            await _smsServiceRepositoryFacade.UpdateMessageDeliveryRecordAsync(messageDeliveryId,
                MessageDeliveryStatus.FailFromProvider, smsSendResult.ErrorMessage, null, cancellationToken);

            return new Result<long>(StatusCodes.GenericFailedError, "Failed to send Sms");
        }

        await _smsServiceRepositoryFacade.UpdateMessageDeliveryRecordAsync(messageDeliveryId,
            MessageDeliveryStatus.SuccessFromProvider, "Failed to send to provider",
            smsSendResult.MessageId, cancellationToken);

        return new Result<long>(StatusCodes.Success, "Sms sent successfully", messageDeliveryId);
    }
}