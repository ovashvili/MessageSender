using MessageSender.Domain.Contracts;

namespace MessageSender.Persistence.Repositories;

public class SmsRepository(AppDbContext dbContext) : ISmsRepository
{
    public async Task<long> InsertSmsAsync(Guid clientId, string phoneNumber, CancellationToken cancellationToken = default)
    {
        var sms = new Sms
        {
            ClientId = clientId,
            PhoneNumber = phoneNumber,
            CreateDate = DateTime.UtcNow
        };

        dbContext.Smses.Add(sms);
        await dbContext.SaveChangesAsync(cancellationToken);

        return sms.SmsId;
    }

    public async Task UpdateSmsContentAsync(long smsId, string content, CancellationToken cancellationToken = default)
    {
        var sms = await dbContext.Smses
            .FirstOrDefaultAsync(s => s.SmsId == smsId, cancellationToken);

        if (sms != null)
        {
            sms.Message = content;
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}