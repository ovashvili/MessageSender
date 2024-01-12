using MessageSender.IntegrationsCommon.Contracts;
using MessageSender.IntegrationsCommon.ProviderResults;
using MessageSender.MagtiIntegration.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace MessageSender.MagtiIntegration.Services;

public class MagtiIntegrationService : ISmsIntegrationService
{
    public int ProviderId { get; set; }
    private readonly HttpClient _httpClient;
    private readonly MagtiOptions _magtiOptions;
    private readonly ILogger<MagtiIntegrationService> _logger;

    public MagtiIntegrationService(
        HttpClient httpClient,
        IOptionsMonitor<MagtiOptions> magtiOptions,
        ILogger<MagtiIntegrationService> logger)
    {
        _httpClient = httpClient;
        _magtiOptions = magtiOptions.CurrentValue;
        _logger = logger;
        ProviderId = _magtiOptions.ProviderId;
    }

    public async Task<SmsProviderResult> SendAsync(string from, string to, string text,
        CancellationToken cancellationToken = default)
    {
        var baseUrl = $"{_magtiOptions.BaseAddress}/mt/oneway";
        
        var uri = $"{baseUrl}" +
                  $"?username={_magtiOptions.UserName}" +
                  $"&password={_magtiOptions.Password}" +
                  $"&to={to}" +
                  $"&text={text}";

        try
        {
            // using var response = await _httpClient.GetAsync(uri, cancellationToken);
            // var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

            if (_logger.IsEnabled(LogLevel.Information))
                _logger.LogInformation("Sending sms...");
            
            return SmsProviderResult.Success("528");
            
        }
        catch (Exception ex)
        {
            if (_logger.IsEnabled(LogLevel.Critical))
                _logger.LogCritical("Error while sending sms with Magti: {Message}", ex.Message);
        }

        return SmsProviderResult.Failure(errorMessage: "Error while sending sms with magti");
    }
}