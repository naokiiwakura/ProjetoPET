using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProjetoPET.Models
{
    public class Usuario : TipoUsuario
    {
        public string Nome { get; set; }
        private string Email { get; set; }
        [StringLength(10)]
        [Display(Description ="Entre com Sua Senha...")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*)[A-Za-z]{10,}$", ErrorMessage = "Senha Inválida")]
        private string Senha { get; set; }
    }
}
