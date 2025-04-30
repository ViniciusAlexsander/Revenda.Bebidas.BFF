using Npgsql;

namespace Revenda.Bebidas.BFF.Infra.DbAdapter.Context
{
    internal static class DbContextProvider
    {
        public static NpgsqlConnection Create(DbAdapterConfiguration configuration)
        {
            var connection = new NpgsqlConnection(configuration.ConnectionString);
            connection.Open(); // optional: open it here, or let the caller do it
            return connection;
        }
    }
}
