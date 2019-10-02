
using System.Collections.Generic;

namespace Domain.Model
{
    public class Telefone : EntityBase
    {
        public string Numero{ get; set; }
        public TipoTelefone Tipo { get; set; }
        public virtual ICollection<Anuncio> Anuncios { get; set; }
    }
}
