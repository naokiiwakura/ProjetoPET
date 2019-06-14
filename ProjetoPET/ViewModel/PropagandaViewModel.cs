using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.ViewModel
{
    public class PropagandaViewModel
    {
        public string Banner { get; set; }
        public string Descricao { get; set; }

        public IFormFile Foto { get; set; }
    }
}
