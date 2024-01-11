using MessageSender.Service.Common.Models;
using MessageSender.Service.Sms.Models;

namespace MessageSender.Service.Sms.Services;

public interface ISmsService
{
    Task<Result<long>> SendAsync(SendSmsDto dto, Guid clientId, CancellationToken cancellationToken = default);
}