using ContactManager.Domains;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data;

public class ContactDbContext : DbContext
{
    public ContactDbContext(DbContextOptions<ContactDbContext> options)
        : base(options) 
    {
    }

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactDbContext).Assembly);

        modelBuilder.Entity<Contact>().HasQueryFilter(c => !c.IsDeleted);
    }
}