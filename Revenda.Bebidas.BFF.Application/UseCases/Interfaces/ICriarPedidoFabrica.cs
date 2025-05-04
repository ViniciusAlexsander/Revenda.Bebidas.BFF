using Revenda.Bebidas.BFF.Application.Ports.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Bebidas.BFF.Application.UseCases.Interfaces
{
    public interface ICriarPedidoFabrica
    {
        Task<string> Execute(CriarPedidoFabricaInput input);
    }
}
