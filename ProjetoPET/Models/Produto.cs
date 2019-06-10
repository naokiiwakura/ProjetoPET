using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.Models
{
    public class Produto : EntityBase
    {
        public string Banner { get; set; }
        public string Descricao { get; set; }
        public byte[] Foto { get; set; }

    }
}
