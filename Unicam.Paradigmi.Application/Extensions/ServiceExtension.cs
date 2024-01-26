using FluentValidation;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Services;

namespace Unicam.Paradigmi.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(
    AppDomain.CurrentDomain.GetAssemblies().
           SingleOrDefault(assembly => assembly.GetName().Name == "Unicam.Paradigmi.Application")
    );

            services.AddScoped<IAziendaService, AziendaService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
