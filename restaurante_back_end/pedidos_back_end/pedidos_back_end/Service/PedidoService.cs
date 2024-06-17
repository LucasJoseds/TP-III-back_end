using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pedidos_back_end.Data;
using pedidos_back_end.Model;

namespace pedidos_back_end.Service
{
    public class PedidoService : IPedidoInterface
    {
        private readonly AppDbContext _context;

        private readonly CardapioService _cardapioService;

        public PedidoService(AppDbContext context, CardapioService cardapioService)
        {
            _context = context;
            _cardapioService = cardapioService;
        }

        public async Task<Pedido> CriarPedido(Pedido pedido)
        {
            var cliente = await _context.Clientes.FindAsync(pedido.ClienteId);
            var novaLista = new List<ItemPedido>();


            foreach (ItemPedido item in pedido.Itens)
            {
                var cardapio = await _cardapioService.BuscarPorId(item.CardapioId);

                var addItem = new ItemPedido
                {
                    Id = item.Id,
                    Quantidade = item.Quantidade,
                    CardapioId = cardapio.Id,
                    Valor = item.Valor,
                };
                novaLista.Add(addItem);
            }

            var novoPedido = new Pedido
            {
                Cliente = cliente,
                DataPedido = DateTime.UtcNow,
                Status = StatusPedido.Preparando,
                Itens = novaLista,
                NumeroMesa = pedido.NumeroMesa
            };

            _context.Pedidos.Add(novoPedido);
            await _context.SaveChangesAsync();
            return novoPedido;
        }

        public IEnumerable<Pedido> ListarPedidos()
        {
            var pedidos = _context.Pedidos
                          .Include(p => p.Itens)
                          .ThenInclude(i => i.Cardapio)
                          .ToList();
                          return pedidos;
        }

        public async Task<IEnumerable<Pedido>> ListarPedidosCliente(int IdDoCliente)
        {
            var pedidos = await _context.Pedidos.Where(p => p.ClienteId == IdDoCliente).Include(p => p.Itens).ThenInclude(i => i.Cardapio).ToListAsync();
          
            return pedidos;
        }

        public async Task<Pedido> AtualizarStatusPedido(int pedidoId, StatusPedido novoStatus)
        {
            var pedido = await _context.Pedidos.FindAsync(pedidoId);
            if (pedido == null)
            {
                throw new Exception("Pedido não encontrado");
            }

            pedido.Status = novoStatus;
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }
    }
}