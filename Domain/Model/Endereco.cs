using System.Collections.Generic;

namespace Domain.Model
{
    public class Endereco : EntityBase
    {
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public virtual ICollection<Anuncio> Anuncios { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<Loja> Lojas { get; set; }
    }
}