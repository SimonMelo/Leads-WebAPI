using Leads.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Leads.Infra.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        public DbSet<Agent> Agents => Set<Agent>();
        public DbSet<Property> Properties => Set<Property>();
        public DbSet<Lead> Leads => Set<Lead>();
        public DbSet<PropertyPhotos> PropertiesPhotos => Set<PropertyPhotos>();
        public DbSet<LeadSource> LeadsSource => Set<LeadSource>();
        public DbSet<LeadNote> LeadsNote => Set<LeadNote>();
        public DbSet<Office> Office => Set<Office>();
        public DbSet<Address> Addresses => Set<Address>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
