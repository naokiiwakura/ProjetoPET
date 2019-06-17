using Microsoft.AspNetCore.Http;
using ProjetoPET.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.ViewModel
{
    public class AdocaoViewModel : EntityBase
    {
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairo { get; set; }
        public string Telefone { get; set; }
        public IFormFile Photo { get; set; }
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

    }
}
