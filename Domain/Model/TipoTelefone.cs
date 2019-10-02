using System.Collections.Generic;

namespace Domain.Model
{
    public class TipoTelefone : EntityBase
    {
        public string Descricao { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
    }
}