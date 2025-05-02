namespace Revenda.Bebidas.BFF.Application.Ports.Pedidos
{
    public class CriarPedidoClienteInput
    {
        public Guid RevendaId { get; set; }
        public ClienteInput Cliente { get; set; }
        public IEnumerable<ProdutoInput> Produtos { get; set; }

        public class ClienteInput
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
        }

        public class ProdutoInput
        {
            public Guid ProdutoId { get; set; }
            public int Quantidade { get; set; }
        }
    }
}
