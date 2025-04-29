namespace Revenda.Bebidas.BFF.Application.Ports.Revendas
{
    public class CadastrarRevendasInput
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string NomeContato { get; set; }
        public string EnderecoEntrega { get; set; }
    }
}
