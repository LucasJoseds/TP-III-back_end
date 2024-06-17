using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pedidos_back_end.Model;
using Cliente = pedidos_back_end.Model.Cliente;
using Pedido = pedidos_back_end.Model.Pedido;

namespace pedidos_back_end.Service
{
    public interface IPedidoInterface
    {
        Task<Pedido> CriarPedido(Pedido pedido);
        IEnumerable<Pedido> ListarPedidos();
       Task<IEnumerable<Pedido>> ListarPedidosCliente(int IdDoCliente);

        Task<Pedido> AtualizarStatusPedido(int pedidoId, StatusPedido novoStatus);


    }
    
}