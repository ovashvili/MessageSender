using MessageSender.Domain.Contracts;

namespace MessageSender.Persistence.Repositories;

public class SmsRepository : ISmsRepository
{
    public Task<int> InsertSmsAsync(Guid clientId, string phoneNumber, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateSmsContentAsync(int smsId, string content, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}