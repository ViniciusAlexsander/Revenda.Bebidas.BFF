using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Revenda.Bebidas.BFF.Domain.Adapters;

namespace Revenda.Bebidas.BFF.Infra.DbAdapter.DependencyInjection
{
    public static class DbAdapterCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, DbAdapterConfiguration dbAdapterConfiguration)
        {
            services.AddSingleton<DbAdapterConfiguration>(dbAdapterConfiguration);

            services.AddTransient<NpgsqlConnection>(_ =>
                new NpgsqlConnection(dbAdapterConfiguration.ConnectionString));
            services.AddScoped<IRevendaDbAdapter, RevendaDbAdapter>();
            services.AddScoped<IClientesDbAdapter, ClientesDbAdapter>();
            services.AddScoped<IPedidosDbAdapter, PedidosDbAdapter>();
            services.AddScoped<IItensPedidoDbAdapter, ItensPedidoDbAdapter>();

            return services;
        }
    }
}
