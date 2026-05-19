using Leads.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Leads.Infra.Persistence.EntityConfiguration
{
    public class PropertyPhotoConfiguration : IEntityTypeConfiguration<PropertyPhotos>
    {
        public void Configure(EntityTypeBuilder<PropertyPhotos> builder)
        {
            builder.ToTable("PropertyPhotos");
            builder.HasKey(ph => ph.Id);
            builder.Property(ph => ph.Url).IsRequired().HasMaxLength(500);
            builder.Property(ph => ph.Order).IsRequired().HasDefaultValue(0);
            builder.Property(ph => ph.IsPrimary).IsRequired().HasDefaultValue(false);
            builder.HasOne(ph => ph.Property)
            .WithMany(p => p.Photos)
            .HasForeignKey(ph => ph.PropertyId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
