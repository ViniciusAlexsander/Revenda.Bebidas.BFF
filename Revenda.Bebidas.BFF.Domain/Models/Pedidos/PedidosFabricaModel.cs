using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Bebidas.BFF.Domain.Models.Pedidos
{
    public class PedidosFabricaModel
    {
        public Guid Id { get; set; }
        public Guid RevendaId { get; set; }
        public string Status { get; set; }
    }
}
