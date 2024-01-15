using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MessageSender.PelekaIntegration.Models;
using System.Text;
using System.Text.Json;
using MessageSender.IntegrationsCommon.Contracts;
using MessageSender.IntegrationsCommon.ProviderResults;
using MessageSender.PelekaIntegration.Configurations;

namespace MessageSender.PelekaIntegration.Services;

public class PelekaIntegrationService : ISmsIntegrationService
{
    public int ProviderId { get; set; }
    private readonly HttpClient _httpClient;
    private readonly PelekaOptions _pelekaOptions;
    private readonly ILogger<PelekaIntegrationService> _logger;

    public PelekaIntegrationService(HttpClient httpClient, IOptionsMonitor<PelekaOptions> pelekaOptions,
        ILogger<PelekaIntegrationService> logger)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(pelekaOptions.CurrentValue.BaseAddress);
        _pelekaOptions = pelekaOptions.CurrentValue;
        _logger = logger;
        ProviderId = _pelekaOptions.ProviderId;
    }

    public async Task<SmsProviderResult> SendAsync(string from, string to, string text, CancellationToken cancellationToken = default)
    {
        var message = new SmsMessage(to, text, _pelekaOptions.Token);
        var data = JsonSerializer.Serialize(message);

        using var content = new StringContent(data, Encoding.UTF8, "application/json");

        try
        {
            // using var response = await _httpClient.PostAsync("message", content, cancellationToken);
            // var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            // var deserializedContent = JsonSerializer.Deserialize<PelekaResponse>(responseContent);

            if (_logger.IsEnabled(LogLevel.Information))
                _logger.LogInformation("Sending sms via Peleka...");
            
            return SmsProviderResult.Success("3");
        }
        catch (Exception ex)
        {
            if (_logger.IsEnabled(LogLevel.Critical))
                _logger.LogCritical("Error while sending sms with Peleka: {Message}", ex.Message);
        }

        return SmsProviderResult.Failure(errorMessage: "Error while sending sms with Peleka");
    }
}