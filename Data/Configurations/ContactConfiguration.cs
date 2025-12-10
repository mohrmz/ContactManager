using ContactManager.Data.Helpers;
using ContactManager.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactManager.Data.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

        builder.Property(c => c.Name).HasMaxLength(200);
        builder.Property(c => c.Email).HasMaxLength(150);
        builder.Property(c => c.Phone).HasMaxLength(50);
        builder.Property(c => c.Address).HasMaxLength(300);
        builder.Property(c => c.City).HasMaxLength(100);
        builder.Property(c => c.State).HasMaxLength(100);
        builder.Property(c => c.Country).HasMaxLength(100);
        builder.Property(c => c.ZipCode).HasMaxLength(20);
        builder.Property(c => c.CurrencyCode).HasMaxLength(10);
        builder.Property(c => c.Reference).HasMaxLength(100);
        builder.Property(c => c.FileNumber).HasMaxLength(50);

        builder.Property(c => c.TaxNumber)
               .HasConversion(JsonValueConverter.Create<object>());

        builder.Property(c => c.Website)
               .HasConversion(JsonValueConverter.Create<object>());

    }
}
