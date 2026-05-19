using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Leads.Domain.Entities;

namespace Leads.Infra.Persistence.EntityConfiguration

{
    public class LeadConfiguration : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.ToTable("Leads");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Name).IsRequired().HasMaxLength(100);
            builder.Property(l => l.Email).IsRequired().HasMaxLength(150);
            builder.Property(l => l.Phone).IsRequired().HasMaxLength(20);
            builder.Property(l => l.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(30);

            builder.HasOne(l => l.Source)
            .WithMany(s => s.Leads)
            .HasForeignKey(l => l.SourceId)
            .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(l => l.InterestedProperty)
            .WithMany()
            .HasForeignKey(l => l.InterestedPropertyId)
            .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(l => l.Agent)
           .WithMany(a => a.Leads)
           .HasForeignKey(l => l.AgentId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(l => new { l.Email, l.OfficeId })
            .IsUnique()
            .HasDatabaseName("IX_Leads_Email_OfficeId");

            builder.HasMany(l => l.Notes)
            .WithOne(n => n.Lead)
            .HasForeignKey(n => n.LeadId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}