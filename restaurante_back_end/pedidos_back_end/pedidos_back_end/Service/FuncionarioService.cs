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



        public async Task<Funcionario> Cadastrar(Funcionario nFuncionario)
        {
             _context.Add(nFuncionario);

          await _context.SaveChangesAsync();

          return nFuncionario;
        }

        
    }
}