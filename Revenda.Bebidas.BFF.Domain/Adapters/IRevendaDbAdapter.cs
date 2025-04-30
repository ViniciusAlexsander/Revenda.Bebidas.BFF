using Revenda.Bebidas.BFF.Domain.Models.Revenda;

namespace Revenda.Bebidas.BFF.Domain.Adapters
{
    public interface IRevendaDbAdapter
    {
        Task InserirRevenda(RevendaModel revendaModel);
    }
}
