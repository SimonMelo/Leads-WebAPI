using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Leads.Domain.Entities;

namespace Leads.Infra.Persistence.EntityConfiguration
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Properties");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(150);
            builder.Property(p => p.RentPrice).IsRequired().HasMaxLength(8);

            builder.Property(p => p.Status).IsRequired().HasConversion<string>().HasMaxLength(20);
            builder.Property(p => p.Type).IsRequired().HasConversion<string>().HasMaxLength(20);

            builder.OwnsOne(p => p.Address, address =>
            {
                address.Property(a => a.Street).IsRequired().HasMaxLength(30);
                address.Property(a => a.Number).IsRequired().HasMaxLength(5);
                address.Property(a => a.Complement).HasMaxLength(100);
                address.Property(a => a.Neighborhood).IsRequired().HasMaxLength(30);
                address.Property(a => a.City).IsRequired().HasMaxLength(30);
                address.Property(a => a.State).IsRequired().HasMaxLength(30);
                address.Property(a => a.ZipCode).IsRequired().HasMaxLength(9);
                address.Property(a => a.Country).IsRequired().HasMaxLength(30);
            });
        }
    }
}