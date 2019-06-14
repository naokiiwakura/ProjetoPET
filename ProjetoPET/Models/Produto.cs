using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace ProjetoPET.Models
{
    public class Produto : EntityBase
    {
        public string Banner { get; set; }
        public string Descricao { get; set; }

        public string Foto { get; set; }
    }
}
