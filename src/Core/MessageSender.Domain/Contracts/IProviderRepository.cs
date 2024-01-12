using MessageSender.Domain.Entities;

namespace MessageSender.Domain.Contracts;

public interface IProviderRepository
{
    Task<IEnumerable<Provider>> GetProvidersAsync(CancellationToken cancellationToken = default);
    Task<Provider?> GetProviderAsync(string providerName, CancellationToken cancellationToken = default);
    Task<IEnumerable<CountryProvider>> GetCountryProvidersAsync(string alpha2Code, CancellationToken cancellationToken = default);
}