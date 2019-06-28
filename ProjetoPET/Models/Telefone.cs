using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.Models
{
    public class Telefone : EntityBase
    {
        public string Numero{ get; set; }
        public TipoTelefone Tipo { get; set; }
    }
}
