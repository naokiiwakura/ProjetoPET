using System.Collections.Generic;

namespace Domain.Model
{
    public class TipoUsuario : EntityBase
    {
        public string Descricao { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}