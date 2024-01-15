using MessageSender.Domain.Contracts;
using MessageSender.Domain.Enums;

namespace MessageSender.Persistence.Repositories;

public class MessageDeliveryRepository(AppDbContext dbContext) : IMessageDeliveryRepository
{
    public async Task<int?> GetSmsStatusAsync(long smsId, CancellationToken cancellationToken = default)
    {
        return await dbContext.MessageDelivery
            .AsNoTracking()
            .Where(md => md.SmsId == smsId)
            .Select(md => (int?)md.Status)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<long> InsertMessageDeliveryStatusAsync(MessageDeliveryStatus status, long? smsId = null, int? providerId = null,
        string? statusNote = null, CancellationToken cancellationToken = default)
    {
        var messageDelivery = new MessageDelivery
        {
            Status = status,
            SmsId = smsId,
            ProviderId = providerId,
            StatusNote = statusNote,
        };

        dbContext.MessageDelivery.Add(messageDelivery);
        await dbContext.SaveChangesAsync(cancellationToken);

        return messageDelivery.MessageDeliveryId;
    }

    public async Task UpdateMessageDeliveryStatusAsync(long messageDeliveryId, MessageDeliveryStatus status, string? providerMessageId,
        string? statusNote = null, CancellationToken cancellationToken = default)
    {
        var messageDelivery = await dbContext.MessageDelivery
            .FirstOrDefaultAsync(md => md.MessageDeliveryId == messageDeliveryId, cancellationToken);

        if (messageDelivery != null)
        {
            messageDelivery.Status = status;
            messageDelivery.ProviderMessageId = providerMessageId;
            messageDelivery.StatusNote = statusNote;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}