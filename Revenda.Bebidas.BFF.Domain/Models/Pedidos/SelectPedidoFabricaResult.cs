namespace Revenda.Bebidas.BFF.Domain.Models.Pedidos
{
    public class SelectPedidoFabricaResult
    {
        public Guid Id { get; set; }
        public Guid RevendaId { get; set; }
        public string Status { get; set; }
        public int TentativasEnvio { get; set; }
        public string MensagemErro { get; set; }
    }
}
