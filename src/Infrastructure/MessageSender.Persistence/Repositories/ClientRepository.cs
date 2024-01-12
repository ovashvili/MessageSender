using MessageSender.Domain.Contracts;

namespace MessageSender.Persistence.Repositories;

public class ClientRepository : IClientRepository
{
    public Task<IEnumerable<Client>> GetClientsAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Client> GetClientAsync(Guid clientId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}