using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pedidos_back_end.Model;
using pedidos_back_end.DTO;

namespace pedidos_back_end.Service
{
    public interface IClienteInterface
    {
        Task<Cliente> AdicionarCliente(Cliente nCliente);

        Task<ClienteDTO> BuscarPorId(int Id);
    }
}