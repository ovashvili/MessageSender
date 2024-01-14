using MessageSender.IntegrationsCommon.Contracts;
using MessageSender.IntegrationsCommon.ProviderResults;
using MessageSender.SilknetIntegration.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MessageSender.SilknetIntegration.Services;

public class SilknetIntegrationService : ISmsIntegrationService
{
    public int ProviderId { get; set; }
    private readonly HttpClient _httpClient;
    private readonly SilknetOptions _silknetOptions;
    private readonly ILogger<SilknetIntegrationService> _logger;

    public SilknetIntegrationService(
        HttpClient httpClient,
        IOptionsMonitor<SilknetOptions> silknetOptions,
        ILogger<SilknetIntegrationService> logger)
    {
        _httpClient = httpClient;
        _silknetOptions = silknetOptions.CurrentValue;
        _logger = logger;
        ProviderId = _silknetOptions.ProviderId;
    }

    public async Task<SmsProviderResult> SendAsync(string from, string to, string text,
        CancellationToken cancellationToken = default)
    {
        var uri = $"{_silknetOptions.BaseAddress}" +
                  $"?src={from}" +
                  $"&dst={to}" +
                  $"&txt={text}";

        try
        {
            // using var response = await _httpClient.GetAsync(uri, cancellationToken);
            // var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

            if (_logger.IsEnabled(LogLevel.Information))
                _logger.LogInformation("Sending sms via Silknet...");
            
            return SmsProviderResult.Success("2");
        }
        catch (Exception ex)
        {
            if (_logger.IsEnabled(LogLevel.Critical))
                _logger.LogCritical("Error while sending sms with Geocell: {Message}", ex.Message);
        }

        return SmsProviderResult.Failure(errorMessage: "Error while sending sms with Geocell");
    }
}