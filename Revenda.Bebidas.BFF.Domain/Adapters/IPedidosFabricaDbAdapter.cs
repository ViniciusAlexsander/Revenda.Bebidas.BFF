using Revenda.Bebidas.BFF.Domain.Enums;
using Revenda.Bebidas.BFF.Domain.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Bebidas.BFF.Domain.Adapters
{
    public interface IPedidosFabricaDbAdapter
    {
        Task<PedidosFabricaModel> InserirPedido(PedidosFabricaModel pedidosFabricaModel);
        Task<IEnumerable<SelectPedidoFabricaResult>> SelectPedidosFabrica(string status);
        Task AtualizarPedidos(StatusPedido status, IEnumerable<Guid> pedidosIds);
    }
}
