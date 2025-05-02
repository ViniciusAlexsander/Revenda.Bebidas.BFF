using Revenda.Bebidas.BFF.Domain.Adapters;
using Revenda.Bebidas.BFF.Domain.Models.Clientes;
using System.Data;

namespace Revenda.Bebidas.BFF.Infra.DbAdapter
{
    internal class ClientesDbAdapter : BaseDbAdapter, IClientesDbAdapter
    {
        public ClientesDbAdapter(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        private static readonly string INSERIR_CLIENTE = @"
            INSERT INTO
            public.clientes 
                (id, 
                nome, 
                email,
                telefone)
            VALUES(uuid_generate_v4(), @Nome, @Email, @Telefone)
            RETURNING
	            *;
        ";

        public async Task<ClienteModel> InserirCliente(ClienteModel clienteModel)
        {
            var response = await QueryAsync<ClienteModel>(INSERIR_CLIENTE, clienteModel);
            return response.FirstOrDefault();
        }
    }
}
