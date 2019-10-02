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
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public virtual Cidade Cidade { get; set; }
        public int CidadeId { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
    }
}