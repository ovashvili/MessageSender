using MessageSender.Domain.Contracts;

namespace MessageSender.Persistence.Repositories;

public class GreyListRepository(AppDbContext dbContext) : IGreyListRepository
{
    public async Task<IEnumerable<GreyList>> GetContactsAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.GreyList
            .AsNoTracking()
            .Where(c => c.IsActive)
            .ToListAsync(cancellationToken);
    }

    public async Task<GreyList?> GetContactAsync(string contactIdentifier, CancellationToken cancellationToken = default)
    {
        return await dbContext.GreyList
            .AsNoTracking()
            .FirstOrDefaultAsync(g => g.ContactIdentifier == contactIdentifier && g.IsActive, cancellationToken);
    }
}