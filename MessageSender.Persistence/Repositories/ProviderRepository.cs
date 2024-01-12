using MessageSender.Domain.Contracts;

namespace MessageSender.Persistence.Repositories;

public class ProviderRepository : IProviderRepository
{
    public Task<IEnumerable<Provider>> GetProvidersAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Provider?> GetProviderAsync(string providerName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CountryProvider>> GetCountryProvidersAsync(string alpha2Code, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}