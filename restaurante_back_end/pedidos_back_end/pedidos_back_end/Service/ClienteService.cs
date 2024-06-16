using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pedidos_back_end.Data;
using pedidos_back_end.Model;
using pedidos_back_end.DTO;

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
            var cliente = new Cliente
            {
                Nome = nCliente.Nome,
                Cpf = nCliente.Cpf,
                Telefone = nCliente.Telefone,
                Email = nCliente.Email,
                Senha = BCrypt.Net.BCrypt.HashPassword(nCliente.Senha)
            };
            _context.Add(cliente);

            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> BuscarPorId(int Id)
        {
            var cliente = await _context.Clientes.FindAsync(Id);
            if (cliente == null)
            {
                return null;
            }

            return cliente;
        }

        public async Task<Cliente> BuscarPorEmail(string email)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<bool> AtualizarCliente(ClienteAtualizadoDTO clienteDTO)
        {
            var cliente = await _context.Clientes.FindAsync(clienteDTO.Id);
            if (cliente == null)
            {
                return false;
            }

            if (!BCrypt.Net.BCrypt.Verify(clienteDTO.SenhaAtual, cliente.Senha))
            {
                return false;
            }

            cliente.Nome = clienteDTO.Nome;
            cliente.Cpf = clienteDTO.Cpf;
            cliente.Telefone = clienteDTO.Telefone;
            cliente.Email = clienteDTO.Email;

            if (!string.IsNullOrEmpty(clienteDTO.NovaSenha))
            {
                cliente.Senha = BCrypt.Net.BCrypt.HashPassword(clienteDTO.NovaSenha);
            }

            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
