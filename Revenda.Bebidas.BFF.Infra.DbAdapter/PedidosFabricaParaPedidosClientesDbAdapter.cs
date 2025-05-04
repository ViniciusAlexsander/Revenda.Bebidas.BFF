using Revenda.Bebidas.BFF.Domain.Adapters;
using Revenda.Bebidas.BFF.Domain.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Bebidas.BFF.Infra.DbAdapter
{
    public class PedidosFabricaParaPedidosClientesDbAdapter : BaseDbAdapter, IPedidosFabricaParaPedidosClientesDbAdapter
    {
        public PedidosFabricaParaPedidosClientesDbAdapter(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        private static readonly string INSERIR_VINCULO = @"
            INSERT INTO
            public.pedidos_fabrica_para_pedidos_cliente 
                (id,
                pedido_fabrica_id,
                pedido_cliente_id)
            VALUES(uuid_generate_v4(), @PedidoFabricaId, @PedidoClienteId);
        ";

        private static readonly string SELECT_PEDIDOS_POR_ID = @"
            SELECT 
                id, 
                pedido_fabrica_id AS PedidoFabricaId, 
                pedido_cliente_id AS PedidoClienteId
            FROM public.pedidos_fabrica_para_pedidos_cliente
            WHERE pedido_fabrica_id=@PedidoFabricaId;
        ";

        public async Task InserirVinculoPedidos(IEnumerable<PedidosFabricaPedidosClienteModel> pedidosFabricaPedidosClienteModels)
        {
            await ExecuteAsync(INSERIR_VINCULO, pedidosFabricaPedidosClienteModels);
        }

        public async Task<IEnumerable<PedidosFabricaPedidosClienteModel>> SelectPedidosPorPedidoFabricaId(Guid PedidoFabricaId)
        {
            return await QueryAsync<PedidosFabricaPedidosClienteModel>(SELECT_PEDIDOS_POR_ID, new { PedidoFabricaId });
        }
    }
}
