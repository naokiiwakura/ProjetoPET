using System.Collections.Generic;

namespace Domain.Model
{
    public class Loja : EntityBase
    {
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public int CNPJ { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public Cidade Cidade { get; set; }
        public int CidadeId { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
    }
}