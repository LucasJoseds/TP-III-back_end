using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace pedidos_back_end.Model
{
    public class Cliente : Pessoa
    {

    
        public string? Email {get;set;}

         [JsonIgnore]
        public string? Senha {get;set;}

        public string Role { get; set; } = "Cliente";

    }
}