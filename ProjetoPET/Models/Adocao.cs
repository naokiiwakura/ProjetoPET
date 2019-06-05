using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjetoPET.Models
{
    public class Adocao : EntityBase
    {
        public string Contato { get; set; }
        public virtual Pet Pet { get; set; }
        public virtual UsuarioBusiness UsuarioBusiness { get; set; }
        [ForeignKey("PetId")]
        public int PetId { get; set; }
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        public ICollection<Pet> PetDoacao { get; set; }

    }
}
