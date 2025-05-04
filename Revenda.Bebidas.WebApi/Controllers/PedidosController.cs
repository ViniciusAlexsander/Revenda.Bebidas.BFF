using Microsoft.AspNetCore.Mvc;
using Revenda.Bebidas.BFF.Application.Ports.Pedidos;
using Revenda.Bebidas.BFF.Application.UseCases.Interfaces;
using Revenda.Bebidas.WebApi.Dtos.Pedidos;

namespace Revenda.Bebidas.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly ICriarPedidoCliente _criarPedidoCliente;
        private readonly ICriarPedidoFabrica _criarPedidoFabrica;
        public PedidosController(ICriarPedidoCliente criarPedidoCliente, ICriarPedidoFabrica criarPedidoFabrica)
        {
            _criarPedidoCliente = criarPedidoCliente ??
                throw new ArgumentNullException(nameof(criarPedidoCliente));
            _criarPedidoFabrica = criarPedidoFabrica ??
                throw new ArgumentNullException(nameof(criarPedidoFabrica));
        }

        [HttpPost("clientes")]
        public async Task<IActionResult> PostPedidoCliente([FromBody] PostPedidoCliente postPedidoCliente)
        {
            var response = await _criarPedidoCliente.Execute(new CriarPedidoClienteInput
            {
                RevendaId = postPedidoCliente.RevendaId,
                Cliente = new CriarPedidoClienteInput.ClienteInput
                {
                    Email = postPedidoCliente.Cliente.Email,
                    Nome = postPedidoCliente.Cliente.Nome,
                    Telefone = postPedidoCliente.Cliente.Telefone,
                },
                Produtos = postPedidoCliente.Produtos.Select(p => new CriarPedidoClienteInput.ProdutoInput
                {
                    ProdutoId = p.ProdutoId,
                    Quantidade = p.Quantidade
                })
            });

            return Created("", response);
        }

        [HttpPost("fabrica")]
        public async Task<IActionResult> Criar([FromBody] PostPedidoFabrica postPedidoFabrica)
        {
            string result = await _criarPedidoFabrica.Execute(new CriarPedidoFabricaInput
            {
                RevendaId = postPedidoFabrica.RevendaId
            });
            return Ok(new { mensagem = result });
        }
    }
}
