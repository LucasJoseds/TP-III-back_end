using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pedidos_back_end.Model;
using pedidos_back_end.Service;

namespace pedidos_back_end.Controllers
{
    [ApiController]
    [Route("api/cardapio")]
    public class CardapioController : ControllerBase
    {

        private readonly CardapioService _service;
        public CardapioController(CardapioService cardapio)
        {
            _service = cardapio;
        }


        [HttpPost("adicionar")]
        public Task<Cardapio> Adicionar(Cardapio c)
        {
            return _service.Cadastrar(c);

        }

        [HttpGet("listar-todos")]
        public Task<List<Cardapio>> ListarTodos(){

            return _service.ListarTodos();
        }
    }
}