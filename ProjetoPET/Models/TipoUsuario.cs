using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.Models
{
    public class TipoUsuario : EntityBase
    {
        public int TipoUsuarioId { get; set; }
        public string Descricao { get; set; }

        public virtual Usuario Usuario { get; set; }
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
