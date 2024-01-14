using MessageSender.Domain.Entities;

namespace MessageSender.Domain.Contracts;

public interface ISmsRepository
{
    Task<long> InsertSmsAsync(Guid clientId, string phoneNumber, CancellationToken cancellationToken = default);
    Task UpdateSmsContentAsync(int smsId, string content, CancellationToken cancellationToken = default);
}