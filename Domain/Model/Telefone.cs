using System.Collections.Generic;

namespace Domain.Model
{
    public class Telefone : EntityBase
    {
        public string Numero { get; set; }
        public virtual TipoTelefone TipoTelefone { get; set; }
        public int TipoTelefoneId { get; set; }
        public virtual Anuncio Anuncio { get; set; }
        public int AnuncioId { get; set; }
        public virtual Evento Evento  { get; set; }
        public int EventoId { get; set; }
        public virtual Loja Loja { get; set; }
        public int LojaId { get; set; }
    }
}