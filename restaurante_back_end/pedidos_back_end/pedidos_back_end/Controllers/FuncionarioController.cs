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
        
         [HttpPost("adicionar")]
        public async Task<Funcionario> Adicionar([FromForm] Funcionario funcionario)
        {

            return await _service.AdicionarFuncionario(funcionario);
        }
    }
}