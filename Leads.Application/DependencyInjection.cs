using Leads.Application.Interfaces.Services.Password;
using Leads.Application.Interfaces.Services.Token;
using Leads.Application.Services.Auth;
using Leads.Application.Services.Password;
using Leads.Application.Services.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Leads.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            //services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ITokenService, TokenService>();
           // services.AddScoped<ILeadService, LeadService>();
            //services.AddScoped<IPropertyService, PropertyService>();

            return services;
        }
    }
}