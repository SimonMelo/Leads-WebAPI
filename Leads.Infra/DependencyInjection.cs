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
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(
                    Environment.GetEnvironmentVariable("ConnectionStrings_DB"),
                    ServerVersion.AutoDetect(Environment.GetEnvironmentVariable("ConnectionStrings_DB"))
                ));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();

            services.AddScoped<IUserContext, UserContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}