using Microsoft.Extensions.DependencyInjection;
using Revenda.Bebidas.BFF.Application.UseCases.Interfaces;
using Revenda.Bebidas.BFF.Application.UseCases.Revendas;
using System.Diagnostics.CodeAnalysis;

namespace Revenda.Bebidas.BFF.Application.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public static class ApplicationCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, ApplicationConfiguration applicationConfiguration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (applicationConfiguration == null)
            {
                throw new ArgumentNullException(nameof(applicationConfiguration));
            }

            services.AddSingleton(applicationConfiguration);

            services.AddScoped<ICadastrarRevendas, CadastrarRevendas>();
            return services;
        }
    }
}
