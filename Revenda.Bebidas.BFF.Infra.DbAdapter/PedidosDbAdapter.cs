using Revenda.Bebidas.BFF.Domain.Adapters;
using Revenda.Bebidas.BFF.Domain.Models.Pedidos;
using Revenda.Bebidas.BFF.Domain.Models.Revenda;
using System.Data;

namespace Revenda.Bebidas.BFF.Infra.DbAdapter
{
    public class PedidosDbAdapter : BaseDbAdapter, IPedidosDbAdapter
    {
        public PedidosDbAdapter(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        private static readonly string INSERIR_PEDIDO = @"
            INSERT INTO
            public.pedidos 
                (id,
                cliente_id,
                revenda_id,
                status)
            VALUES(uuid_generate_v4(), @ClienteId, @RevendaId, @Status)
            RETURNING
                id,
                cliente_id AS ClienteId,
                revenda_id AS RevendaId,
                status;
        ";

        private static readonly string SELECT_PEDIDO_CLIENTE = @"
            SELECT 
                p.id AS ProdutoId,
                p.nome AS NomeProduto,
                p.descricao AS Descricao,
                p.preco AS Preco,
                ip.quantidade AS Quantidade
            FROM pedidos pd
            JOIN itens_pedido ip ON pd.id = ip.pedido_id
            JOIN produtos p ON p.id = ip.produto_id
            WHERE pd.id = @PedidoId
              AND pd.cliente_id = @ClienteId;
        ";

        public async Task<PedidoModel> InserirPedido(PedidoModel pedidoModel)
        {
            var response = await QueryAsync<PedidoModel>(INSERIR_PEDIDO, pedidoModel);
            return response.FirstOrDefault();
        }

        public async Task<IEnumerable<SelectPedidoClienteResult>> SelectPedidoCliente(Guid pedidoId, Guid clienteId)
        {
            return await QueryAsync<SelectPedidoClienteResult>(SELECT_PEDIDO_CLIENTE, new { PedidoId = pedidoId, ClienteId = clienteId });
        }
    }
}
