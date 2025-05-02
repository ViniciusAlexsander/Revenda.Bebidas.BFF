namespace Revenda.Bebidas.BFF.Application.Ports.Pedidos
{
    public class CriarPedidoClienteOutput
    {
        public Guid PedidoId { get; set; }
        public IEnumerable<ProdutoOutput> Produtos { get; set; }
        public class ProdutoOutput
        {
            public Guid ProdutoId { get; set; }
            public string NomeProduto { get; set; }
            public string Descricao { get; set; }
            public decimal Preco { get; set; }
            public int Quantidade { get; set; }
        }
    }
}
