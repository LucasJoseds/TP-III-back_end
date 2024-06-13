using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pedidos_back_end.Service;
using pedidos_back_end.DTO;


namespace pedidos_back_end.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {

        private readonly ClienteService _service;
        private readonly JwtService _jwtService;

        public AuthController(ClienteService service, JwtService jwtService)
        {
            _service = service;
            _jwtService = jwtService;
        }



        [HttpPost]
        public async Task<IActionResult> Autenticar([FromBody] LoginDTO dto)
        {
            var vCliente = await _service.BuscarPorEmail(dto.Email);
            if (vCliente == null)
            {
                return Unauthorized(new { message = "Email ou senha incorretos" });
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Senha, vCliente.Senha))
            {
                return Unauthorized(new { message = "Email ou senha incorretos" });
            }

            var jwt = _jwtService.Generate(vCliente.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });


            return Ok(new { message = "Autenticação bem-sucedida", jwt, vCliente });
        }
    }
}