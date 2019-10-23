using System.Collections.Generic;

namespace Domain.Model
{
    public class Loja : EntityBase
    {
        public string NomeLoja { get; set; }
        public string RazaoSocial { get; set; }
        public int CNPJ { get; set; }
        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public int CEP { get; set; }
        public Cidade Cidade { get; set; }
        public int CidadeId { get; set; }
        public List<Telefone> Telefones { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public string NomeFantasia { get; set; }
    }
}
