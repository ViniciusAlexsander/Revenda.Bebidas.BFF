using Revenda.Bebidas.BFF.Application.Ports.Revendas;
using Revenda.Bebidas.BFF.Application.UseCases.Interfaces;

namespace Revenda.Bebidas.BFF.Application.UseCases.Revendas
{
    public class CadastrarRevendas : ICadastrarRevendas
    {
        public async Task Execute(CadastrarRevendasInput input)
        {
            if (string.IsNullOrEmpty(input.Cnpj))
                throw new Exception();

            await Task.Delay(1000);
        }
    }
}
