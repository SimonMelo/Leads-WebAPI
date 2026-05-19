using FluentValidation;
using Leads.Application;
using Leads.Application.Behaviors;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Leads.WebAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApi(
        this IServiceCollection services)
    {
        services.AddControllers();

        services.AddHttpContextAccessor();

        services.AddEndpointsApiExplorer();

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),

                        ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),

                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(
                                    Environment.GetEnvironmentVariable("JWT_KEY")
                                )
                            )
                    };
            });

        services.AddAuthorization();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Leads API",
                Version = "v1"
            });

            options.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Digite: Bearer {seu token}"
                });

            options.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
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