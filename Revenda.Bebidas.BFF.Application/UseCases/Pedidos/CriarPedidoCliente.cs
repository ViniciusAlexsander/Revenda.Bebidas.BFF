using Revenda.Bebidas.BFF.Application.Ports.Pedidos;
using Revenda.Bebidas.BFF.Application.UseCases.Interfaces;
using Revenda.Bebidas.BFF.Domain.Adapters;
using Revenda.Bebidas.BFF.Domain.Models.Clientes;
using Revenda.Bebidas.BFF.Domain.Models.Pedidos;
using Revenda.Bebidas.BFF.Domain.Models.Revenda;

namespace Revenda.Bebidas.BFF.Application.UseCases.Pedidos
{
    public class CriarPedidoCliente : ICriarPedidoCliente
    {
        private readonly IClientesDbAdapter _clientesDbAdapter;
        private readonly IPedidosDbAdapter _pedidosDbAdapter;
        private readonly IItensPedidoDbAdapter _itensPedidoDbAdapter;

        public CriarPedidoCliente(IClientesDbAdapter clientesDbAdapter, IPedidosDbAdapter pedidosDbAdapter, IItensPedidoDbAdapter itensPedidoDbAdapter)
        {
            _clientesDbAdapter = clientesDbAdapter;
            _pedidosDbAdapter = pedidosDbAdapter;
            _itensPedidoDbAdapter = itensPedidoDbAdapter;
        }

        public async Task<CriarPedidoClienteOutput> Execute(CriarPedidoClienteInput input)
        {
            var novoCliente = await _clientesDbAdapter.InserirCliente(new ClienteModel
            {
                Email = input.Cliente.Email,
                Nome = input.Cliente.Nome,
                Telefone = input.Cliente.Telefone,
            });

            var novoPedido = await _pedidosDbAdapter.InserirPedido(new PedidoModel
            {
                ClienteId = novoCliente.Id,
                RevendaId = input.RevendaId,
                Status = "Pendente",
            });

            await _itensPedidoDbAdapter.InserirItensPedido(input.Produtos.Select(p => new ItensPedidoModel
            {
                PedidoId = novoPedido.Id,
                ProdutoId = p.ProdutoId,
                Quantidade = p.Quantidade,
            }));

            var response = await _pedidosDbAdapter.SelectPedidoCliente(novoPedido.Id, novoCliente.Id);

            return new CriarPedidoClienteOutput
            {
                PedidoId = novoPedido.Id,
                Produtos = response.Select(p => new CriarPedidoClienteOutput.ProdutoOutput
                {
                    Descricao = p.Descricao,
                    NomeProduto = p.NomeProduto,
                    Preco = p.Preco,
                    ProdutoId = p.ProdutoId,
                    Quantidade = p.Quantidade,
                })
            };
        }
    }
}
