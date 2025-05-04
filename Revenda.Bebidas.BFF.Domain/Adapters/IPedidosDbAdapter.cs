using Revenda.Bebidas.BFF.Domain.Enums;
using Revenda.Bebidas.BFF.Domain.Models.Pedidos;
using Revenda.Bebidas.BFF.Domain.Models.Revenda;

namespace Revenda.Bebidas.BFF.Domain.Adapters
{
    public interface IPedidosDbAdapter
    {
        Task<PedidoModel> InserirPedido(PedidoModel pedidoModel);
        Task<IEnumerable<SelectPedidoClienteResult>> SelectPedidoCliente(Guid pedidoId, Guid clienteId);
        Task<IEnumerable<SelectPedidosClientePendentesResult>> SelectPedidoClientePendentes(Guid revendaId);
        Task AtualizarStatusPedido(StatusPedido status, IEnumerable<Guid> pedidosIds);
    }
}
