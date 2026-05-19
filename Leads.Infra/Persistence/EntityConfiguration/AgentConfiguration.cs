using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Leads.Domain.Entities;
using Leads.Domain.Enum;

namespace Leads.Infra.Persistence.EntityConfiguration
{
    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.ToTable("Agents");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Phone).IsRequired().HasMaxLength(20);
            builder.Property(a => a.CPF).IsRequired().HasMaxLength(14);
            builder.Property(a => a.Password).IsRequired().HasMaxLength(255);
            builder.Property(a => a.CRECI).IsRequired().HasMaxLength(20);

            builder.Property(a => a.Role)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasDefaultValue(EAgentRole.Agent);
            builder.Property(a => a.IsActive).IsRequired().HasDefaultValue(true);
            builder.HasIndex(a => a.Email).IsUnique();
            builder.HasIndex(a => a.CRECI).IsUnique();

            builder.HasOne(a => a.Office)
            .WithMany(o => o.Agents)
            .HasForeignKey(a => a.OfficeId)
            .OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(a => a.Properties)
            .WithOne(p => p.Agent)
            .HasForeignKey(p => p.AgentId)
            .OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(a => a.Leads)
            .WithOne(l => l.Agent)
            .HasForeignKey(l => l.AgentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }

    }
