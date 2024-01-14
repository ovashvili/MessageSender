using MessageSender.Application.Sms.Contracts;
using MessageSender.IntegrationsCommon.Contracts;

namespace MessageSender.Application.Sms.Services;

public class SmsIntegrationFactory : ISmsIntegrationFactory
{
    private readonly IEnumerable<ISmsIntegrationService> _integrations;

    public SmsIntegrationFactory(IEnumerable<ISmsIntegrationService> integrations)
    {
        _integrations = integrations;
    }

    public ISmsIntegrationService? Create(int providerId)
    {
        return _integrations.FirstOrDefault(p => p.ProviderId == providerId);
    }
}
