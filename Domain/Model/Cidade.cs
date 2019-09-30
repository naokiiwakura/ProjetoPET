using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.Models
{
    public class Cidade : EntityBase
    {
        public string Nome { get; set; }
        public Estado Estado { get; set; }
    }
}
