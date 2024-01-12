using MessageSender.IntegrationsCommon.ProviderResults;

namespace MessageSender.IntegrationsCommon.Contracts;

public interface ISmsIntegrationService
{
    public int ProviderId { get; set; }
    public Task<SmsProviderResult> SendAsync(string from, string to, string content, CancellationToken cancellationToken = default);
}