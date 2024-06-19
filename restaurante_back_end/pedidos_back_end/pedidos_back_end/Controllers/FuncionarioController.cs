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
    [Route("api/funcionario")]
    public class FuncionarioController : ControllerBase
    {


        private readonly FuncionarioService _funcionarioService;

        public FuncionarioController(FuncionarioService funcionarioService)
        {
            _funcionarioService=funcionarioService;
            
        }

        [HttpGet]
        public async Task<ActionResult<Funcionario>> BuscarFuncionario([FromQuery] int Id)
        {

            var funcionario = await _funcionarioService.BuscarPorId(Id);

            if (funcionario == null)
            {
                return NotFound(new { message = "Funcionario não encontrado" });
            }
            return funcionario;
        }

        [HttpPost("adicionar")]
        public async Task<Funcionario> Adicionar([FromForm] Funcionario funcionario)
        {

            return await _funcionarioService.AdicionarFuncionario(funcionario);
        }
    }
}