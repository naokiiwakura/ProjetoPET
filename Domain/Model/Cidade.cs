using System.Collections.Generic;

namespace Domain.Model
{
    public class Cidade : EntityBase
    {
        public string Nome { get; set; }
        public virtual Estado Estado { get; set; }
        public int EstadoId { get; set; }
        public ICollection<Evento> Eventos { get; set; }
        public ICollection<Anuncio> Anuncios { get; set; }
        public ICollection<Loja> Lojas { get; set; }
    }
}