using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using ProjetoPET.Areas.Identity.Data;

namespace ProjetoPET.Models
{
    public class Anuncio : EntityBase
    {
        internal object uniqueFileName;

        public string Titulo { get; set; }

        public string CorpoAnuncio { get; set; }

        public string Foto { get; set; }

        [ForeignKey("PetId")]
        public virtual Pet Pet { get; set; }

        public virtual Usuario Anunciante { get; set; }

        [ForeignKey("TipoAnuncioId")]
        public TipoAnuncio TipoAnuncio { get; set; }

        public int TipoAnuncioId { get; set; }

        public int PetId { get; set; }

        [ForeignKey("EnderecoId")]
        public Endereco Endereco { get; set; }

        public int EnderecoId { get; set; }

        public ICollection<Telefone> Telefones { get; set; }
    }
}