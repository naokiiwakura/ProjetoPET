using System.Collections.Generic;

namespace Domain.Model
{
    public class Estado : EntityBase
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public ICollection<Cidade> Cidades { get; set; }
    }
}