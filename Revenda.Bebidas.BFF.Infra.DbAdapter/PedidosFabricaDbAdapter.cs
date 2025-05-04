using Revenda.Bebidas.BFF.Domain.Adapters;
using Revenda.Bebidas.BFF.Domain.Enums;
using Revenda.Bebidas.BFF.Domain.Models.Pedidos;
using Revenda.Bebidas.BFF.Domain.Models.Revenda;
using System.Data;

namespace Revenda.Bebidas.BFF.Infra.DbAdapter
{
    public class PedidosFabricaDbAdapter : BaseDbAdapter, IPedidosFabricaDbAdapter
    {
        public PedidosFabricaDbAdapter(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        private static readonly string INSERIR_PEDIDO = @"
            INSERT INTO
            public.pedidosfabrica 
                (id,
                revenda_id,
                status)
            VALUES(uuid_generate_v4(), @RevendaId, @Status)
            RETURNING
                id,
                revenda_id AS RevendaId,
                status;
        ";

        private static readonly string SELECT_PEDIDOS_FABRICA = @"
            SELECT 
                id as Id, 
                revenda_id as RevendaId,
                status as Status, 
                tentativas_envio as TentativasEnvio, 
                mensagem_erro as MensagemErro
            FROM public.pedidosfabrica
            WHERE status = @Status;
        ";

        private static readonly string ATUALIZAR_STATUS_PEDIDOS = @"
            UPDATE pedidosfabrica
            SET status = @NovoStatus
            WHERE id = ANY(@Ids);
        ";

        public async Task<PedidosFabricaModel> InserirPedido(PedidosFabricaModel pedidosFabricaModel)
        {
            var response = await QueryAsync<PedidosFabricaModel>(INSERIR_PEDIDO, pedidosFabricaModel);
            return response.FirstOrDefault();
        }

        public async Task<IEnumerable<SelectPedidoFabricaResult>> SelectPedidosFabrica(string status)
        {
            return await QueryAsync<SelectPedidoFabricaResult>(SELECT_PEDIDOS_FABRICA, new { Status = status });
        }

        public async Task AtualizarPedidos(StatusPedido status, IEnumerable<Guid> pedidosIds)
        {
            await ExecuteAsync(ATUALIZAR_STATUS_PEDIDOS, new { NovoStatus = status.ToString(), Ids = pedidosIds.ToList() });
        }
    }
}
