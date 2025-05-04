using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Bebidas.BFF.Domain.Models.Pedidos
{
    public class PedidosFabricaPedidosClienteModel
    {
        public Guid PedidoFabricaId { get; set; }
        public Guid PedidoClienteId { get; set; }
    }
}
