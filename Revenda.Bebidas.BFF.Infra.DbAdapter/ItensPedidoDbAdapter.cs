using Revenda.Bebidas.BFF.Domain.Adapters;
using Revenda.Bebidas.BFF.Domain.Models.Pedidos;
using System.Data;

namespace Revenda.Bebidas.BFF.Infra.DbAdapter
{
    internal class ItensPedidoDbAdapter : BaseDbAdapter, IItensPedidoDbAdapter
    {
        public ItensPedidoDbAdapter(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        private static readonly string INSERIR_ITEM_PEDIDO = @"
            INSERT INTO
            public.itens_pedido 
                (id,
                pedido_id,
                produto_id, 
                quantidade)
            VALUES(uuid_generate_v4(), @PedidoId, @ProdutoId, @Quantidade);
        ";

        public async Task InserirItensPedido(IEnumerable<ItensPedidoModel> itens)
        {
            await ExecuteAsync(INSERIR_ITEM_PEDIDO, itens);
        }
    }
}
