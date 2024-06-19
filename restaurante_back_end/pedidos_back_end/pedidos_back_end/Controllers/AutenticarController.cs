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
    [Route("api/autenticar")]
    public class AutenticarController : ControllerBase
    {
        private readonly FuncionarioService _funcionarioService;
        private readonly JwtService _jwtService;

        public AutenticarController(JwtService jwtService, FuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
            _jwtService = jwtService;
        }

        [HttpPost("funcionario")]
        public async Task<IActionResult> AutenticarFuncionario([FromBody] LoginDTO dto)
        {
            var funcionario = await _funcionarioService.BuscarPorEmail(dto.Email);

            if (funcionario == null)
            {
                return Unauthorized(new { message = "Email ou senha incorretos" });
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Senha, funcionario.Senha))
            {
                return Unauthorized(new { message = "Email ou senha incorretos" });
            }

            var jwt = _jwtService.Generate(funcionario.Id);

            Response.Cookies.Append("jwt_funcionario", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new { message = "Autenticação de funcionário bem-sucedida", jwt, funcionario });
        }


        [HttpPost("funcionario/logout")]
        public IActionResult LogoutFuncionario()
        {
            Response.Cookies.Delete("jwt_funcionario");

            return Ok(new { message = "Logout de funcionário bem-sucedido" });
        }
    }
}