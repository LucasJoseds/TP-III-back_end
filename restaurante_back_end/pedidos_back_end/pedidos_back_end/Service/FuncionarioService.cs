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
    public class FuncionarioService: IFuncionarioService
    {

        private readonly AppDbContext _context;

         public FuncionarioService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<Funcionario> AdicionarFuncionario(Funcionario nFuncionario)
        {
            var func = new Funcionario
            {
                Nome = nFuncionario.Nome,
                Cpf = nFuncionario.Cpf,
                Telefone = nFuncionario.Telefone,
                Email = nFuncionario.Email,
                Senha = BCrypt.Net.BCrypt.HashPassword(nFuncionario.Senha)
            };
            _context.Add(func);

            await _context.SaveChangesAsync();
            return func;
        }
        public async Task<Funcionario> BuscarPorEmail(string email)
        {
            return await _context.Funcionarios.FirstOrDefaultAsync(f => f.Email == email);
        }

        public async Task<Funcionario> BuscarPorId(int Id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(Id);
            if (funcionario == null)
            {
                return null;
            }

            return funcionario;
        }

    }
}