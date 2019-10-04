using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public class Evento : EntityBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public Cidade Cidade { get; set; }
        public int CidadeId { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
