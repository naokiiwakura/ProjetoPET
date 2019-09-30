using System.Collections.Generic;

namespace Domain.Model
{
    public class Pet : EntityBase
    {
        public string Nome{get;set;}
        public string Raca { get; set; }
        public int Idade{get;set;}
        public string Sexo{get;set;}
        public string Telefone{get;set;}
        public string Descricao { get; set; }
        public virtual ICollection<Anuncio> Anuncios { get; set; }
    }
}
