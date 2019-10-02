using System.Collections.Generic;

namespace Domain.Model
{
    public class TipoAnuncio : EntityBase
    {
        public string Descricao { get; set; }
        public virtual ICollection<Anuncio> Anuncios { get; set; }
    }
}