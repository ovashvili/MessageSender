using MessageSender.Domain.Contracts;

namespace MessageSender.Persistence.Repositories;

public class ClientRepository(AppDbContext dbContext) : IClientRepository
{
    public async Task<IEnumerable<Client>> GetClientsAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Clients
            .AsNoTracking()
            .Where(c => c.IsActive)
            .ToListAsync(cancellationToken);
    }

    public async Task<Client?> GetClientAsync(Guid clientId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Clients
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ClientId == clientId && c.IsActive, cancellationToken);
    }
}