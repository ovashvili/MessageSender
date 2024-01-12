using MessageSender.Domain.Contracts;

namespace MessageSender.Persistence.Repositories;

public class GreyListRepository : IGreyListRepository
{
    public Task<IEnumerable<GreyList>> GetContactsAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<GreyList?> GetContactAsync(string contactIdentifier, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}