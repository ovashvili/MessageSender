using MessageSender.Application.Common.Models;
using MessageSender.Application.Sms.Models;

namespace MessageSender.Application.Sms.Services;

public interface ISmsService
{
    Task<Result<long>> SendAsync(SendSmsDto dto, Guid clientId, CancellationToken cancellationToken = default);
}