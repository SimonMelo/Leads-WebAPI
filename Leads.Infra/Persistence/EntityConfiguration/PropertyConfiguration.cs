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
            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);

            builder.Property(p => p.SalePrice).HasPrecision(18, 2);
            builder.Property(p => p.RentPrice).HasPrecision(18, 2);
            builder.Property(p => p.AreaM2).HasPrecision(10, 2);
            builder.Property(p => p.Bedrooms).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.Bathrooms).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.Status)
            .IsRequired().HasConversion<string>().HasMaxLength(20);
            builder.Property(p => p.Type)
            .IsRequired().HasConversion<string>().HasMaxLength(20);

            builder.OwnsOne(p => p.Address, address =>
            {
                address.Property(a => a.Street).IsRequired().HasMaxLength(100);
                address.Property(a => a.Number).IsRequired().HasMaxLength(10);
                address.Property(a => a.Complement).HasMaxLength(100);
                address.Property(a => a.Neighborhood).IsRequired().HasMaxLength(60);
                address.Property(a => a.City).IsRequired().HasMaxLength(60);
                address.Property(a => a.State).IsRequired().HasMaxLength(2);
                address.Property(a => a.ZipCode).IsRequired().HasMaxLength(9);
            });

            builder.HasMany(p => p.Photos)
            .WithOne(ph => ph.Property)
            .HasForeignKey(ph => ph.PropertyId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
    }