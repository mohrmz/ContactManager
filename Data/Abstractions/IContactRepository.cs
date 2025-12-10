using ContactManager.Domains;

namespace ContactManager.Data.Abstractions;

public interface IContactRepository
{
    Task<Contact> Create(Contact contact, CancellationToken cancellationToken);
    Task<Contact?> GetById(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Contact>> GetAll(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<Contact> Update(Contact contact, CancellationToken cancellationToken);
    Task Delete(int id, CancellationToken cancellationToken);
    Task<bool> Exists(int id, CancellationToken cancellationToken);
    Task<int> Count(CancellationToken cancellationToken);
}
