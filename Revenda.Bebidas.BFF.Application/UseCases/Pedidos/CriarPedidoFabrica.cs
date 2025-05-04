using Revenda.Bebidas.BFF.Application.Ports.Pedidos;
using Revenda.Bebidas.BFF.Application.UseCases.Interfaces;
using Revenda.Bebidas.BFF.Domain.Adapters;
using Revenda.Bebidas.BFF.Domain.Enums;
using Revenda.Bebidas.BFF.Domain.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Bebidas.BFF.Application.UseCases.Pedidos
{
    public class CriarPedidoFabrica: ICriarPedidoFabrica
    {
        private readonly int QUANTIDADE_PEDIDO_MINIMO = 1000;
        private readonly IPedidosFabricaDbAdapter _pedidosFabricaDbAdapter;
        private readonly IPedidosDbAdapter _pedidosClienteDbAdapter;
        private readonly IPedidosFabricaParaPedidosClientesDbAdapter _pedidosFabricaParaPedidosClientesDbAdapter;

        public CriarPedidoFabrica(IPedidosFabricaDbAdapter pedidosFabricaDbAdapter, IPedidosDbAdapter pedidosClienteDbAdapter, IPedidosFabricaParaPedidosClientesDbAdapter pedidosFabricaParaPedidosClientesDbAdapter)
        {
            _pedidosFabricaDbAdapter = pedidosFabricaDbAdapter;
            _pedidosClienteDbAdapter = pedidosClienteDbAdapter;
            _pedidosFabricaParaPedidosClientesDbAdapter = pedidosFabricaParaPedidosClientesDbAdapter;
        }

        public async Task<string> Execute(CriarPedidoFabricaInput input)
        {
            var produtos = await _pedidosClienteDbAdapter.SelectPedidoClientePendentes(input.RevendaId);

            if(produtos.Count() == 0)
            {
                return "Não existe nenhum pedido pendente";
            }
            
            int quantidadeTotalProdutos = 0;
            List<Guid> pedidosId = [];
            
            foreach(SelectPedidosClientePendentesResult produto in produtos)
            {
                quantidadeTotalProdutos += produto.Quantidade;
                if (!pedidosId.Contains(produto.PedidoId))
                {
                    pedidosId.Add(produto.PedidoId);
                }
            }

            if (quantidadeTotalProdutos >= QUANTIDADE_PEDIDO_MINIMO)
            {
                var pedidoFabrica = await _pedidosFabricaDbAdapter.InserirPedido(new PedidosFabricaModel
                {
                    RevendaId = input.RevendaId,
                    Status = StatusPedido.Pendente.ToString(),
                });

                await _pedidosFabricaParaPedidosClientesDbAdapter.InserirVinculoPedidos(pedidosId.Select(pedidoClienteId => new PedidosFabricaPedidosClienteModel
                {
                    PedidoClienteId = pedidoClienteId,
                    PedidoFabricaId = pedidoFabrica.Id
                }));

                await _pedidosClienteDbAdapter.AtualizarStatusPedido(StatusPedido.EmProcessamento, pedidosId);

                return "Novo pedido criado com sucesso";
            }
            return $"Não atingiu a capacidade miníma de {QUANTIDADE_PEDIDO_MINIMO} itens para completar esse pedido";
        }
    }
}
