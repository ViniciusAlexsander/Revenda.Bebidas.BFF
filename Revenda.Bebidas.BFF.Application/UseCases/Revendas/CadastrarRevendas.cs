using Revenda.Bebidas.BFF.Application.Ports.Revendas;
using Revenda.Bebidas.BFF.Application.UseCases.Interfaces;
using Revenda.Bebidas.BFF.Domain.Adapters;
using Revenda.Bebidas.BFF.Domain.Models.Revenda;

namespace Revenda.Bebidas.BFF.Application.UseCases.Revendas
{
    public class CadastrarRevendas : ICadastrarRevendas
    {
        private readonly IRevendaDbAdapter _revendaDbAdapter;

        public CadastrarRevendas(IRevendaDbAdapter revendaDbAdapter)
        {
            _revendaDbAdapter = revendaDbAdapter;
        }

        public async Task Execute(CadastrarRevendasInput input)
        {
            if (string.IsNullOrEmpty(input.Cnpj))
                throw new Exception();

            await _revendaDbAdapter.InserirRevenda(new RevendaModel
            {
                Cnpj = input.Cnpj,
                Email = input.Email,
                EnderecoEntrega = input.EnderecoEntrega,
                NomeContato = input.NomeContato,
                NomeFantasia = input.NomeFantasia,
                RazaoSocial = input.RazaoSocial,
                Telefone = input.Telefone,
            });
        }
    }
}
