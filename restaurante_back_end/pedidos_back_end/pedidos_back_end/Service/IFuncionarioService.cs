using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pedidos_back_end.Model;


namespace pedidos_back_end.Service
{
    public interface IFuncionarioService
    {
          Task<Funcionario> AdicionarFuncionario(Funcionario nFuncionario);

        Task<Funcionario> BuscarPorId(int Id);

    }
}