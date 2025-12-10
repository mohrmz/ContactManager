using ContactManager.Data.Abstractions;
using ContactManager.Domains;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly ContactDbContext _context;

    public ContactRepository(ContactDbContext context)
    {
        _context = context;
    }

    public async Task<Contact> Create(Contact contact, CancellationToken cancellationToken)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync(cancellationToken);
        return contact;
    }

    public async Task<Contact?> GetById(int id, CancellationToken cancellationToken)
    {
        return await _context.Contacts
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted, cancellationToken);
    }

    public async Task<IEnumerable<Contact>> GetAll(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await _context.Contacts
            .AsNoTracking()
            .Where(c => !c.IsDeleted)
            .OrderBy(c => c.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<Contact> Update(Contact contact, CancellationToken cancellationToken)
    {
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync(cancellationToken);
        return contact;
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        if (contact != null)
        {
            contact.IsDeleted = true; 
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<bool> Exists(int id, CancellationToken cancellationToken)
    {
        return await _context.Contacts.AnyAsync(c => c.Id == id && !c.IsDeleted, cancellationToken);
    }

    public async Task<int> Count(CancellationToken cancellationToken)
    {
        return await _context.Contacts.CountAsync(c => !c.IsDeleted, cancellationToken);
    }
}
