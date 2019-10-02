
using System.Collections.Generic;

namespace Domain.Model
{
    public class TipoUsuario : EntityBase
    {
        public int TipoUsuarioId { get; set; }
        public string Descricao { get; set; }

        public virtual Usuario Usuario { get; set; }
        
        public int UsuarioId { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
