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
            builder.Property(l => l.Email).IsRequired().HasMaxLength(100);
            builder.Property(l => l.Phone).IsRequired().HasMaxLength(12);
            builder.Property(l => l.CPF).IsRequired().HasMaxLength(30);

            builder.Property(l => l.Status)
                   .IsRequired().HasConversion<string>().HasMaxLength(30);

            builder.HasOne<Property>()
                   .WithMany()
                   .HasForeignKey(l => l.InterestedPropertyId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}