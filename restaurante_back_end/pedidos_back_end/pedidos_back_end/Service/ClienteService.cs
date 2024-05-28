using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pedidos_back_end.Data;
using pedidos_back_end.Model;

namespace pedidos_back_end.Service
{
    public class ClienteService : IClienteInterface
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext appContext)
        {

            _context = appContext;
        }
        public async Task<Cliente> AdicionarCliente(Cliente nCliente)
        {
            _context.Add(nCliente);

            await _context.SaveChangesAsync();
            return nCliente;
        }

        public  async Task<Cliente> BuscarPorId(int Id)
        {
           return await _context.Clientes.FindAsync(Id);
        }

      
    }
}