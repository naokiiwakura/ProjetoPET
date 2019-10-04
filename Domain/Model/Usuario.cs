using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain.Model
{
    public partial class Usuario :IdentityUser
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Anuncio> Anuncios{ get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}