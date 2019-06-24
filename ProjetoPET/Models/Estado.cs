using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.Models
{
    public class Estado : EntityBase
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public ICollection<Cidade> Cidades { get; set; }
    }
}
