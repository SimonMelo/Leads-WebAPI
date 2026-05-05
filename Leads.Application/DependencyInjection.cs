using Microsoft.Extensions.DependencyInjection;

namespace Leads.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            
            //services.AddScoped<IAgentService, AgentService>();
           // services.AddScoped<ILeadService, LeadService>();
            //services.AddScoped<IPropertyService, PropertyService>();

            return services;
        }
    }
}