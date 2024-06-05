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
    [Route("api/pedidos")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _service;
        public PedidoController(PedidoService service)
        {
            _service = service;
        }


        [HttpPost]
       public async Task<ActionResult<Pedido>> CriarPedido([FromForm]Pedido pedido){

        return  await _service.CriarPedido(pedido);

       }

       [HttpGet]
       public ActionResult<IEnumerable<Pedido>> ListarPedidos(){
            var pedidos = _service.ListarPedidos();

        return Ok(pedidos);
       }



    }
}