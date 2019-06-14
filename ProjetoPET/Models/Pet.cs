using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProjetoPET.Models
{
    public class Pet : EntityBase
    {
        public string Nome{get;set;}
        public string Raca { get; set; }
        public int Idade{get;set;}
        [StringLength(1)]
        [RegularExpression("[F-M]")]
        public char Sexo{get;set;}
        public string Telefone{get;set;}
        public string Descricao { get; set; }

    }
}
