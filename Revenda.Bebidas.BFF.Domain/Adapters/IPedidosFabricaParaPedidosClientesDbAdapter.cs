using Revenda.Bebidas.BFF.Domain.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Bebidas.BFF.Domain.Adapters
{
    public interface IPedidosFabricaParaPedidosClientesDbAdapter
    {
        Task InserirVinculoPedidos(IEnumerable<PedidosFabricaPedidosClienteModel> pedidosFabricaPedidosClienteModels);
        Task<IEnumerable<PedidosFabricaPedidosClienteModel>> SelectPedidosPorPedidoFabricaId(Guid PedidoFabricaId);
    }
}
