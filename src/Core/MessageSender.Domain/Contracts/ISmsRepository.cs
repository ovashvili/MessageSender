namespace MessageSender.Domain.Contracts;

public interface ISmsRepository
{
    Task<long> InsertSmsAsync(Guid clientId, string phoneNumber, CancellationToken cancellationToken = default);
    Task UpdateSmsContentAsync(long smsId, string content, CancellationToken cancellationToken = default);
}