using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pedidos_back_end.Data;
using pedidos_back_end.Model;

namespace pedidos_back_end.Service
{

    public class CardapioService : ICardapioInterface
    {
        private readonly AppDbContext _context;
        public CardapioService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }



        public async Task<Cardapio> Cadastrar(Cardapio nCardapio)
        {
             _context.Add(nCardapio);

          await _context.SaveChangesAsync();

          return nCardapio;
        }

        public async Task<List<Cardapio>> ListarTodos()
        {
            return await _context.Cardapios.ToListAsync();
        }

        public  async Task<Cardapio> BuscarPorId(int Id)
        {
           return await _context.Cardapios.FindAsync(Id);
        }
    }
}