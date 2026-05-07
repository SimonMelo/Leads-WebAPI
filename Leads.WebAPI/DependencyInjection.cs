using FluentValidation;
using Leads.Application;
using Leads.Application.Behaviors;
using MediatR;
using Microsoft.OpenApi.Models;

namespace Leads.WebAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApi(
        this IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Leads API",
                Version = "v1"
            });
        });

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<DependencyInjectionMarker>();
        });

        services.AddValidatorsFromAssemblyContaining<DependencyInjectionMarker>();

        services.AddTransient(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>)
        );

        return services;
    }
}