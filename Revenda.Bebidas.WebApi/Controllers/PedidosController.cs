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
        public PedidosController(ICriarPedidoCliente criarPedidoCliente)
        {
            _criarPedidoCliente = criarPedidoCliente ??
                throw new ArgumentNullException(nameof(criarPedidoCliente));
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
    }
}
