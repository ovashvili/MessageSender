using MessageSender.Application.Common.Models;
using MessageSender.Application.Sms.Models;
using MessageSender.Domain.Enums;

namespace MessageSender.Application.Sms.Services;

public interface ISmsService
{
    Task<Result<long>> SendAsync(SendSmsDto dto, Guid clientId, CancellationToken cancellationToken = default);
    Task<Result<MessageDeliveryStatus?>> GetStatusAsync(long id, CancellationToken cancellationToken = default);

}