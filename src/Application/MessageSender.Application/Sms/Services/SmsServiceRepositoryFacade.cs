using MessageSender.Application.Sms.Contracts;
using MessageSender.Application.Sms.Extensions;
using MessageSender.Domain.Contracts;
using MessageSender.Domain.Entities;
using MessageSender.Domain.Enums;

namespace MessageSender.Application.Sms.Services;

public class SmsServiceRepositoryFacade : ISmsServiceRepositoryFacade
{
    private readonly ICountryRepository _countryRepository;
    private readonly IGreyListRepository _greyListRepository;
    private readonly IMessageDeliveryRepository _messageDeliveryRepository;
    private readonly IProviderRepository _providerRepository;
    private readonly ISmsRepository _smsRepository;
    private readonly IClientRepository _clientRepository;

    public SmsServiceRepositoryFacade(
        IGreyListRepository greyListRepository,
        ICountryRepository countryRepository,
        IProviderRepository providerRepository,
        ISmsRepository smsRepository,
        IMessageDeliveryRepository messageDeliveryRepository,
        IClientRepository clientRepository)
    {
        _greyListRepository = greyListRepository;
        _countryRepository = countryRepository;
        _providerRepository = providerRepository;
        _smsRepository = smsRepository;
        _messageDeliveryRepository = messageDeliveryRepository;
        _clientRepository = clientRepository;
    }

    public Task<GreyList?> GetGreyListContactAsync(string phoneNumber, CancellationToken cancellationToken = default)
    {
        return _greyListRepository.GetContactAsync(phoneNumber, cancellationToken);
    }

    public Task<Country?> GetCountryAsync(string countryCode, CancellationToken cancellationToken = default)
    {
        return _countryRepository.GetCountryAsync(countryCode, cancellationToken);
    }

    public async Task<List<CountryProvider>> GetCountryProvidersOrderedByPriorityAsync(string alpha2Code,
        CancellationToken cancellationToken = default)
    {
        return (await _providerRepository.GetCountryProvidersAsync(alpha2Code, cancellationToken))
            .OrderBy(cp => cp.Priority)
            .ToList();
    }

    public Task<Provider?> GetProviderAsync(string providerName, CancellationToken cancellationToken = default)
    {
        return _providerRepository.GetProviderAsync(providerName, cancellationToken);
    }

    public async Task<List<Provider>> GetGlobalProvidersOrderedByPriorityAsync(
        CancellationToken cancellationToken = default)
    {
        return (await _providerRepository.GetProvidersAsync(cancellationToken))
            .Where(p => p is { IsGlobal: true })
            .OrderBy(p => p.Priority)
            .ToList();
    }

    public Task<long> InsertSmsAsync(Guid clientId, string phoneNumber, CancellationToken cancellationToken = default)
    {
        return _smsRepository.InsertSmsAsync(clientId, phoneNumber, cancellationToken);
    }

    public Task<long> InsertMessageDeliveryAsync(long smsId, MessageDeliveryStatus status, int? providerId,
        string? statusNote, CancellationToken cancellationToken = default)
    {
        return _messageDeliveryRepository.InsertMessageDeliveryStatusAsync(status, smsId, providerId, statusNote, cancellationToken);
    }

    public Task UpdateMessageDeliveryRecordAsync(long messageDeliveryId, MessageDeliveryStatus status,
        string? statusNote, string? providerMessageId, CancellationToken cancellationToken = default)
    {
        return _messageDeliveryRepository.UpdateMessageDeliveryStatusAsync(messageDeliveryId, status, providerMessageId, statusNote, cancellationToken);
    }

    public async Task<MessageDeliveryStatus> GetSmsStatusAsync(long smsId, CancellationToken cancellationToken = default)
    {
        var smsStatus = await _messageDeliveryRepository.GetSmsStatusAsync(smsId, cancellationToken)
                          ?? throw new InvalidOperationException($"No record found for SmsId: {smsId}");

        return smsStatus.ToMessageDeliveryStatus();
    }

    public Task<Client?> GetClientAsync(Guid clientId, CancellationToken cancellationToken = default)
    {
        return _clientRepository.GetClientAsync(clientId, cancellationToken);
    }
}