using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    public class LojaDto
    {
        public string NomeLoja { get; set; }
        public string RazaoSocial { get; set; }
        public int CNPJ { get; set; }
        public int EnderecoId { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public int CEP { get; set; }
        public int CidadeId { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public string NomeFantasia { get; set; }
    }
}
