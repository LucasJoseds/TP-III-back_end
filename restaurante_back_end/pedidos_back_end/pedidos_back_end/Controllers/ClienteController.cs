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
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        
        private readonly ClienteService _service;

        public ClienteController(ClienteService service){
            _service = service;
        }

        [HttpPost("adicionar")]
        public async Task<Cliente> Adicionar([FromForm]Cliente cliente){

            return await _service.AdicionarCliente(cliente);       
        }

        [HttpGet]
        public async Task<ActionResult<Cliente>> BuscarCliente([FromQuery]int Id){

            var cliente = await _service.BuscarPorId(Id);

            if (cliente == null){
                return NotFound(new { message = "Cliente não encontrado" });
            }
            return cliente;
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> Autenticar([FromForm] string email, [FromForm] string senha)
        {
            var cliente = await _service.BuscarPorEmail(email);
            if (cliente == null || cliente.Senha != senha)
            {
                return Unauthorized(new { message = "Email ou senha incorretos" });
            }
            return Ok(new { message = "Autenticação bem-sucedida", cliente });
        }
    }
}