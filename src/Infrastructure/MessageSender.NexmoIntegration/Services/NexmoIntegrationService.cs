using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MessageSender.IntegrationsCommon.Contracts;
using MessageSender.IntegrationsCommon.ProviderResults;
using MessageSender.NexmoIntegration.Configurations;

namespace MessageSender.NexmoIntegration.Services;

public class NexmoIntegrationService : ISmsIntegrationService
{
    public int ProviderId { get; set; }
    private readonly HttpClient _httpClient;
    private readonly ILogger<NexmoIntegrationService> _logger;

    public NexmoIntegrationService(HttpClient httpClient, IOptionsMonitor<NexmoOptions> nexmoOptions,
        ILogger<NexmoIntegrationService> logger)
    {
        _logger = logger;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(nexmoOptions.CurrentValue.BaseAddress);
        ProviderId = nexmoOptions.CurrentValue.ProviderId;
    }

    public async Task<SmsProviderResult> SendAsync(string from, string to, string text,
        CancellationToken cancellationToken = default)
    {
        // var message = new SmsMessage(from, to, text);
        // var data = JsonSerializer.Serialize(message);
        //
        // using var content = new StringContent(data, Encoding.UTF8, "application/json");

        try
        {
            // using var response = await _httpClient.PostAsync("v1/messages", content, cancellationToken);
            // var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            
            if (_logger.IsEnabled(LogLevel.Information))
                _logger.LogInformation("Sending sms via Nexmo...");

            return SmsProviderResult.Success("4");

        }
        catch (Exception ex)
        {
            if (_logger.IsEnabled(LogLevel.Critical))
                _logger.LogCritical("Error while sending sms with nexmo: {Message}", ex.Message);
        }

        return SmsProviderResult.Failure(errorMessage: "Error while sending sms with nexmo");
    }
}