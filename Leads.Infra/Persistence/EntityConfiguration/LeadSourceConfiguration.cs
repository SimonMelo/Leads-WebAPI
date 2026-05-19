using Leads.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Leads.Infra.Persistence.EntityConfiguration
{
    public class LeadSourceConfiguration : IEntityTypeConfiguration<LeadSource>
    {
        public void Configure(EntityTypeBuilder<LeadSource> builder)
        {
            builder.ToTable("LeadSources");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Channel)
            .IsRequired().HasConversion<string>().HasMaxLength(30);
            builder.HasIndex(s => s.Name).IsUnique();
        }
    }
}
