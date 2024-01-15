using MessageSender.Domain.Contracts;

namespace MessageSender.Persistence.Repositories;

public class CountryRepository(AppDbContext dbContext) : ICountryRepository
{
    public async Task<IEnumerable<Country>> GetCountriesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Countries
            .AsNoTracking()
            .Where(c => c.IsActive)
            .ToListAsync(cancellationToken);
    }

    public async Task<Country?> GetCountryAsync(string countryCode, CancellationToken cancellationToken = default)
    {
        return await dbContext.Countries
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Alpha2Code == countryCode && c.IsActive, cancellationToken);
    }
}