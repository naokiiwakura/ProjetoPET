using System.Collections.Generic;

namespace Domain.Model
{
    // Add profile data for application users by adding properties to the Usuario class
    public partial class Usuario 
    {
        public Endereco Endereco { get; set; }
        public virtual ICollection<Anuncio> Anuncios{ get; set; }
    }
}
