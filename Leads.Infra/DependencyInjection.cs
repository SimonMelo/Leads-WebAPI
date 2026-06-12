using Leads.Application.Interfaces.Context;
using Leads.Domain.Interfaces.Repositories;
using Leads.Domain.Interfaces.Services;
using Leads.Infra.Context;
using Leads.Infra.Persistence;
using Leads.Infra.Repositories;
using Leads.Infra.Storage.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;

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

            services.AddScoped<IStorageService, StorageService>();
            
            services.AddMinio(minioConfig => minioConfig
                .WithEndpoint(Environment.GetEnvironmentVariable("MINIO_ENDPOINT"))
                .WithCredentials(Environment.GetEnvironmentVariable("MINIO_ACCESS_KEY"), 
                    Environment.GetEnvironmentVariable("MINIO_SECRET_KEY"))
                .WithSSL(false)
                .Build());
            
            return services;
        }
    }
}