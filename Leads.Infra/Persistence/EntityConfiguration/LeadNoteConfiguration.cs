using Leads.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Infra.Persistence.EntityConfiguration
{
    public class LeadNoteConfiguration : IEntityTypeConfiguration<LeadNote>
    {
        public void Configure(EntityTypeBuilder<LeadNote> builder)
        {
            builder.ToTable("LeadNotes");
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Content).IsRequired().HasMaxLength(2000);
            builder.HasOne(n => n.Lead)
            .WithMany(l => l.Notes)
            .HasForeignKey(n => n.LeadId)
            .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(n => n.Agent)
            .WithMany()
            .HasForeignKey(n => n.AgentId)
            .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
