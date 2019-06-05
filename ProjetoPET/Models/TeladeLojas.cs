using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.Models
{
    public class TeladeLojas
    {
        [Key]
        public int ID { get; set; }
       public string Nome { get; set; }
        public string Endereco { get; set; }
        public int CNPj { get; set; }
    }
}
