using MessageSender.Domain.Entities;

namespace MessageSender.Domain.Contracts;

public interface ICountryRepository
{
    Task<IEnumerable<Country>> GetCountriesAsync(CancellationToken cancellationToken = default);
    Task<Country?> GetCountryAsync(string countryCode, CancellationToken cancellationToken = default);
}