using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ProjetoPET.Models
{
    public class Pet : EntityBase
    {
        public string Nome{get;set;}
        public string Raca { get; set; }
        public int Idade{get;set;}
        public string Sexo{get;set;}
        public int Telefone{get;set;}
        public string Descricao { get; set; }

    }
}
