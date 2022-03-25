using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using TesteEntrevista.Application.Services;
using TesteEntrevista.Domain.Interfaces.Repositories;
using TesteEntrevista.Domain.Interfaces.Services;
using TesteEntrevista.EF.Repositories;

namespace TesteEntrevista.IoC
{
    [ExcludeFromCodeCoverage]
    public static class Bootstraper
    {
        public static IServiceCollection AddConfigServices(this IServiceCollection services)
        {
            services.AddScoped<ICaminhaoService, CaminhaoService>();
            
            return services;
        }

        public static IServiceCollection AddConfigEF(this IServiceCollection services)
        {
            
            return services;
        }

        public static IServiceCollection AddConfigRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICaminhaoRepository, CaminhaoRepository>();
            
            return services;
        }
    }
}
