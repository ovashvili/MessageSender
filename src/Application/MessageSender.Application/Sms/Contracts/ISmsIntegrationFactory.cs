using MessageSender.IntegrationsCommon.Contracts;

namespace MessageSender.Application.Sms.Contracts;

public interface ISmsIntegrationFactory
{
    ISmsIntegrationService? Create(int providerId);
}