using Revenda.Bebidas.BFF.Domain.Models.Pedidos;

namespace Revenda.Bebidas.BFF.Domain.Adapters
{
    public interface IItensPedidoDbAdapter
    {
        Task InserirItensPedido(IEnumerable<ItensPedidoModel> itens);
    }
}
