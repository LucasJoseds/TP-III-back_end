using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pedidos_back_end.Model;

namespace pedidos_back_end.Service
{
    public interface ICardapioInterface
    {
        Task<List<Cardapio>> ListarTodos();

        Task<Cardapio> Cadastrar(Cardapio nCardapio);

        Task<Cardapio>BuscarPorId(int Id);

        
        
    }
}