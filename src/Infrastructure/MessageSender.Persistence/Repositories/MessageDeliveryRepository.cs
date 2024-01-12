using MessageSender.Domain.Contracts;
using MessageSender.Domain.Enums;

namespace MessageSender.Persistence.Repositories;

public class MessageDeliveryRepository : IMessageDeliveryRepository
{
    public Task<int?> GetSmsStatusAsync(long smsId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<long> InsertMessageDeliveryStatusAsync(MessageDeliveryStatus status, long? smsId = null, int? providerId = null,
        string? statusNote = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateMessageDeliveryStatusAsync(long messageDeliveryId, MessageDeliveryStatus status, string? providerMessageId,
        string? statusNote = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}