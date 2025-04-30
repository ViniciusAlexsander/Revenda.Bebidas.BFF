using Dapper;
using System.Data;

namespace Revenda.Bebidas.BFF.Infra.DbAdapter
{
    public abstract class BaseDbAdapter
    {
        public IDbConnection _dbConnection { get; set; }

        protected BaseDbAdapter(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string query, object parametros)
        {
            return _dbConnection.QueryAsync<T>(query, parametros);
        }

        public Task<int> ExecuteAsync(string query, object parametros)
        {
            return _dbConnection.ExecuteAsync(query, parametros);
        }
    }
}
