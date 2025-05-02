using Revenda.Bebidas.BFF.Domain.Models.Clientes;

namespace Revenda.Bebidas.BFF.Domain.Adapters
{
    public interface IClientesDbAdapter
    {
        Task<ClienteModel> InserirCliente(ClienteModel clienteModel);
    }
}
