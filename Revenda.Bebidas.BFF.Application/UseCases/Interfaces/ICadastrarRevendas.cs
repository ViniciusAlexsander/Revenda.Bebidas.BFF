using Revenda.Bebidas.BFF.Application.Ports.Revendas;

namespace Revenda.Bebidas.BFF.Application.UseCases.Interfaces
{
    public interface ICadastrarRevendas
    {
        Task Execute(CadastrarRevendasInput input);
    }
}
