namespace Revenda.Bebidas.BFF.Domain.Models.Pedidos
{
    public class SelectPedidoClienteResult
    {
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
