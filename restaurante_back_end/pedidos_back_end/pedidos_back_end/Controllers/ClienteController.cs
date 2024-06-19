using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pedidos_back_end.Model;
using pedidos_back_end.Service;
using pedidos_back_end.DTO;

namespace pedidos_back_end.Controllers
{

    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {

        private readonly ClienteService _service;

        private readonly JwtService _jwtService;
        public ClienteController(ClienteService service, JwtService jwtService)
        {
            _service = service;
            _jwtService = jwtService;
        }

        [HttpPost("adicionar")]
        public async Task<Cliente> Adicionar([FromForm] Cliente cliente)
        {

            return await _service.AdicionarCliente(cliente);
        }

        [HttpGet]
        public async Task<ActionResult<Cliente>> BuscarCliente([FromQuery] int Id)
        {

            var cliente = await _service.BuscarPorId(Id);

            if (cliente == null)
            {
                return NotFound(new { message = "Cliente não encontrado" });
            }
            return cliente;
        }



        [HttpGet("cliente")]
        public async Task<IActionResult> Cliente()
        {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                int clienteId = int.Parse(token.Issuer);
                var cliente = await _service.BuscarPorId(clienteId);

                if (cliente == null)
                {
                    return NotFound();
                }

                return Ok(cliente);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarCliente([FromBody] ClienteAtualizadoDTO clienteDTO)
        {
            var atualizado = await _service.AtualizarCliente(clienteDTO);
            if (!atualizado)
            {
                return Unauthorized(new { message = "Senha atual inválida" });
            }

            return Ok(new { message = "Conta atualizada com sucesso" });
        }

        [HttpGet("listar-todos")]
        public Task<List<Cliente>> ListarTodos()
        {

            return _service.ListarTodos();
        }
    }
}