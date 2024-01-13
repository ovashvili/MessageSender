using MessageSender.Application.Common.Models;
using MessageSender.Application.Sms.Models;
using MessageSender.Domain.Enums;

namespace MessageSender.Application.Sms.Services;

public class SmsService : ISmsService
{
    public Task<Result<long>> SendAsync(SendSmsDto dto, Guid clientId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result<MessageDeliveryStatus?>> GetStatusAsync(long id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}