using MessageSender.Domain.Contracts;

namespace MessageSender.Persistence.Repositories;

public class ProviderRepository(AppDbContext dbContext) : IProviderRepository
{
    public async Task<IEnumerable<Provider>> GetProvidersAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Providers
            .AsNoTracking()
            .Where(p => p.IsActive)
            .ToListAsync(cancellationToken);
    }

    public async Task<Provider?> GetProviderAsync(string providerName, CancellationToken cancellationToken = default)
    {
        return await dbContext.Providers
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Name == providerName && p.IsActive, cancellationToken);
    }

    public async Task<IEnumerable<CountryProvider>> GetCountryProvidersAsync(string alpha2Code, CancellationToken cancellationToken = default)
    {
        return await dbContext.CountryProviders
            .AsNoTracking()
            .Include(cp => cp.Provider) 
            .Where(cp => cp.Alpha2Code == alpha2Code && cp.IsActive)
            .ToListAsync(cancellationToken);
    }
}