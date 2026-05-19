using Leads.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Leads.Infra.Persistence.EntityConfiguration
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Offices");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Name).IsRequired().HasMaxLength(150);
            builder.Property(o => o.CNPJ).HasMaxLength(18);
            builder.Property(o => o.Phone).HasMaxLength(20);
            builder.Property(o => o.LogoUrl).HasMaxLength(500);
            builder.Property(o => o.IsActive).IsRequired().HasDefaultValue(true);
            builder.HasIndex(o => o.CNPJ).IsUnique().HasFilter("CNPJ IS NOT NULL");
        }
    }
}
