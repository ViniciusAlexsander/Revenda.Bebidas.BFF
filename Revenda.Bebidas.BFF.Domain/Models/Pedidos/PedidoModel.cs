namespace Revenda.Bebidas.BFF.Domain.Models.Revenda
{
    public class PedidoModel
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Guid RevendaId { get; set; }
        public string Status { get; set; }
    }
}
