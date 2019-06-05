using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.Models
{
    public class UsuarioBusiness : Usuario
    {
        private string CPF {get;set;}
        private  string CNPJ{get;set;}
        [StringLength(10)]
        [Display(Description = "Entre com Sua Senha...")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*)[A-Za-z]{10,}$", ErrorMessage = "Senha Inválida")]
        private string Senha { get; set; }

    }
}
