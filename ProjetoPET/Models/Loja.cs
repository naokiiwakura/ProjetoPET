using ProjetoPET.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPET.Models
{
    public class Loja : EntityBase
    {
        public string NomeLoja { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPj { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        public string UsuarioId { get; set; }

        [ForeignKey("CidadeId")]
        public Cidade Cidade { get; set; }

        public int CidadeId { get; set; }
        public int EstadoId { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
    }
}
