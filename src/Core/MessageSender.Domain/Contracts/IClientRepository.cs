using MessageSender.Domain.Entities;

namespace MessageSender.Domain.Contracts;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetClientsAsync(CancellationToken cancellationToken = default);
    Task<Client> GetClientAsync(Guid clientId, CancellationToken cancellationToken = default);
}