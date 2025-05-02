namespace Revenda.Bebidas.WebApi.Dtos.Pedidos
{
    public class PostPedidoCliente
    {
        public Guid RevendaId { get; set; }
        public ClienteDto Cliente { get; set; }
        public IEnumerable<ProdutoDto> Produtos { get; set; }

        public class ClienteDto
        {
            public string Nome { get; set; }
            public string Email { get; }
            public string Telefone { get; set; }
        }

        public class ProdutoDto
        {
            public Guid ProdutoId { get; set; }
            public int Quantidade { get; set; }
        }
    }
}
