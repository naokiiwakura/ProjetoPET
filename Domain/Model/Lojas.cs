using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.Models
{
    public class Lojas : EntityBase
    {
        public string NomeLoja { get; set; }
        public string RazaoSocial { get; set; }
        public int CNPj { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public int CEP { get; set; }
        
        [ForeignKey("CidadeId")]
        public Cidade Cidade { get; set; }

        public int CidadeId { get; set; }

        public int Telefone { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
    }
}
