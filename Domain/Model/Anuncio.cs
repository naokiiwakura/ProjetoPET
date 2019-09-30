using System.Collections.Generic;

namespace Domain.Model
{
    public class Anuncio : EntityBase
    {
        internal object uniqueFileName;

        public string Titulo { get; set; }

        public string CorpoAnuncio { get; set; }

        public string Foto { get; set; }

        
        public virtual Pet Pet { get; set; }

        public virtual Usuario Anunciante { get; set; }


        public TipoAnuncio TipoAnuncio { get; set; }

        public int TipoAnuncioId { get; set; }

        public int PetId { get; set; }


        public Endereco Endereco { get; set; }

        public int EnderecoId { get; set; }

        public ICollection<Telefone> Telefones { get; set; }
    }
}