using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pedidos_back_end.Model
{
    public class Pessoa
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public string? Nome {get; set;}
        public string? Cpf {get;set;}
        public string? Telefone {get;set;}
    }
}