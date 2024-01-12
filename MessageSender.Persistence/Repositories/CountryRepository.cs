using MessageSender.Domain.Contracts;

namespace MessageSender.Persistence.Repositories;

public class CountryRepository : ICountryRepository
{
    public Task<IEnumerable<Country>> GetCountriesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Country?> GetCountryAsync(string countryCode, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}