using Leads.Application.Interfaces.Context;
using Leads.Application.Interfaces.Repositories;
using Leads.Infra.Context;
using Leads.Infra.Persistence;
using Leads.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leads.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))
                ));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IPropertyPhotoRepository, PropertyPhotoRepository>();
            services.AddScoped<ILeadNoteRepository, LeadNoteRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<ILeadSourceRepository, LeadSourceRepository>();

            services.AddScoped<IUserContext, UserContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}