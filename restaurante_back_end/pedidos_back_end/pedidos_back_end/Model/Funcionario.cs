using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pedidos_back_end.Model
{
    public class Funcionario: Pessoa
    {
        public string Email { get; set; }

        [JsonIgnore]
        public string Senha { get; set; }

        public string Role { get; set; } = "Funcionario";
    }
}