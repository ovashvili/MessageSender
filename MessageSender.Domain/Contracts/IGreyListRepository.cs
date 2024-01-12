using MessageSender.Domain.Entities;

namespace MessageSender.Domain.Contracts;

public interface IGreyListRepository
{
    Task<IEnumerable<GreyList>> GetContactsAsync(CancellationToken cancellationToken = default);
    Task<GreyList?> GetContactAsync(string contactIdentifier, CancellationToken cancellationToken = default);
}