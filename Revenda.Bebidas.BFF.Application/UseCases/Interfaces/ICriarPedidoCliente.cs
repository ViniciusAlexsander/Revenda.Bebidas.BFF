using Revenda.Bebidas.BFF.Application.Ports.Pedidos;

namespace Revenda.Bebidas.BFF.Application.UseCases.Interfaces
{
    public interface ICriarPedidoCliente
    {
        Task<CriarPedidoClienteOutput> Execute(CriarPedidoClienteInput input);
    }
}
