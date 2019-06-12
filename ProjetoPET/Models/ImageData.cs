using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.Models
{
    public class ImageData : EntityBase
    {
        public int ImagemId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        
        public string Conteúdo { get; set; }
        public byte[] Image { get; set; }
    }
}
