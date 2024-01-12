using MessageSender.Application.Common.Models;
using MessageSender.Application.Sms.Models;

namespace MessageSender.Application.Sms.Services;

public class SmsService : ISmsService
{
    public Task<Result<long>> SendAsync(SendSmsDto dto, Guid clientId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}