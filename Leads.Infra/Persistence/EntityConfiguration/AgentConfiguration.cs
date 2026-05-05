using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Leads.Domain.Entities;

namespace Leads.Infra.Persistence.EntityConfiguration
{
    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.ToTable("Agents");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Phone).IsRequired().HasMaxLength(20);
            builder.Property(a => a.CPF).IsRequired().HasMaxLength(30);
            builder.Property(a => a.CRECI).IsRequired().HasMaxLength(20);

            builder.HasMany(a => a.Properties)
                   .WithOne()
                   .HasForeignKey(p => p.AgentId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(a => a.Leads)
                   .WithOne()
                   .HasForeignKey(l => l.AgentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
