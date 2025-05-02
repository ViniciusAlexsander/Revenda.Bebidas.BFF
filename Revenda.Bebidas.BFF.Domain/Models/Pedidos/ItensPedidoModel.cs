namespace Revenda.Bebidas.BFF.Domain.Models.Pedidos
{
    public class ItensPedidoModel
    {
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
