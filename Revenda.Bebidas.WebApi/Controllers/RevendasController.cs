using Microsoft.AspNetCore.Mvc;
using Revenda.Bebidas.BFF.Application.Ports.Revendas;
using Revenda.Bebidas.BFF.Application.UseCases.Interfaces;
using Revenda.Bebidas.WebApi.Dtos.Revendas;

namespace Revenda.Bebidas.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RevendasController : ControllerBase
    {
        private readonly ICadastrarRevendas _cadastrarRevendas;
        public RevendasController(ICadastrarRevendas cadastrarRevendas)
        {
            _cadastrarRevendas = cadastrarRevendas ??
                throw new ArgumentNullException(nameof(cadastrarRevendas));
        }

        [HttpPost()]
        public async Task<IActionResult> PostRevendas([FromBody] PostRevendas postRevendas)
        {
            await _cadastrarRevendas.Execute(new CadastrarRevendasInput
            {
                Cnpj = postRevendas.Cnpj,
                Email = postRevendas.Email,
                EnderecoEntrega = postRevendas.EnderecoEntrega,
                NomeContato = postRevendas.NomeContato,
                NomeFantasia = postRevendas.NomeFantasia,
                RazaoSocial = postRevendas.RazaoSocial,
                Telefone = postRevendas.Telefone
            });

            return Ok();
        }
    }
}
