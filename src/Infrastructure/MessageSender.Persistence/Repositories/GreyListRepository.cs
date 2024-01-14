using MessageSender.Domain.Contracts;
using MessageSender.Persistence.Context;

namespace MessageSender.Persistence.Repositories;

public class GreyListRepository(AppDbContext dbContext) : IGreyListRepository
{
    public async Task<IEnumerable<GreyList>> GetContactsAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.GreyList
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<GreyList?> GetContactAsync(string contactIdentifier, CancellationToken cancellationToken = default)
    {
        return await dbContext.GreyList
            .AsNoTracking()
            .FirstOrDefaultAsync(g => g.ContactIdentifier == contactIdentifier, cancellationToken);
    }
}