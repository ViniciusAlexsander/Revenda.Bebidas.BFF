using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Bebidas.BFF.Domain.Models.Pedidos
{
    public class SelectPedidosClientePendentesResult
    {
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public Guid PedidoId { get; set; }
    }
}
