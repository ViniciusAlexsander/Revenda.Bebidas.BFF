using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Revenda.Bebidas.BFF.Domain.Adapters;
using Revenda.Bebidas.BFF.Domain.Enums;

namespace Revenda.Bebidas.BFF.Infra.Services
{
    public class FilaPedidosBackgroundService : BackgroundService
    {
        private readonly ILogger<FilaPedidosBackgroundService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public FilaPedidosBackgroundService(ILogger<FilaPedidosBackgroundService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var _pedidosFabricaDbAdapter = scope.ServiceProvider.GetRequiredService<IPedidosFabricaDbAdapter>();
                var _pedidosFabricaParaPedidosClientesDbAdapter = scope.ServiceProvider.GetRequiredService<IPedidosFabricaParaPedidosClientesDbAdapter>();
                var _pedidosClienteDbAdapter = scope.ServiceProvider.GetRequiredService<IPedidosDbAdapter>();

                var pedidosPendentes = await _pedidosFabricaDbAdapter.SelectPedidosFabrica(StatusPedido.Pendente.ToString());

                //SIMULA CHAMADA PARA API
                foreach (var pedido in pedidosPendentes)
                {
                    try
                    {
                        var random = new Random();
                        var numero = random.Next(0, 100);

                        if (numero % 2 == 0)
                        {
                            Console.WriteLine("Simulando sucesso na requisição.");
                            await Task.Delay(1000, stoppingToken);

                            var resultPedidos = await _pedidosFabricaParaPedidosClientesDbAdapter.SelectPedidosPorPedidoFabricaId(pedido.Id);
                            if (resultPedidos.Count() > 0)
                                await _pedidosClienteDbAdapter.AtualizarStatusPedido(StatusPedido.Enviado, resultPedidos.Select(pedido => pedido.PedidoClienteId));

                            await _pedidosFabricaDbAdapter.AtualizarPedidos(StatusPedido.Enviado, new List<Guid> { pedido.Id });
                        }
                        else
                        {
                            Console.WriteLine("Simulando erro na requisição.");
                            throw new Exception("Erro simulado na requisição para a fábrica.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Erro ao enviar pedido para a fabrica");
                    }
                }
            }
        }

        private Task<Guid?> BuscarPedidoDaFilaAsync()
        {
            // Simulação. Substitua por leitura de banco, Redis, etc.
            return Task.FromResult<Guid?>(Guid.NewGuid());
        }
    }
}
