using MessageSender.Domain.Enums;

namespace MessageSender.Domain.Contracts;

public interface IMessageDeliveryRepository
{
    Task<int?> GetSmsStatusAsync(long smsId, CancellationToken cancellationToken = default);
    
    Task<long> InsertMessageDeliveryStatusAsync(MessageDeliveryStatus status, long? smsId = null, int? providerId = null,
        string? statusNote = null, CancellationToken cancellationToken = default);
    
    Task UpdateMessageDeliveryStatusAsync(long messageDeliveryId, MessageDeliveryStatus status, string? providerMessageId,
        string? statusNote = null, CancellationToken cancellationToken = default);
}