using Microsoft.AspNetCore.Http;
using ProjetoPET.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.ViewModel
{
    public class LojasViewModel : EntityBase
    {

        [Display(Name = "Nome da Loja")]
        [Required(ErrorMessage = "* O Campo Nome da loja é obrigatório")]
        public string NomeLoja { get; set; }

        [Display(Name = "Razão social")]
        [Required(ErrorMessage = "* O Campo Razão Social é obrigatório")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Cnpj")]
        [Required(ErrorMessage = "* O Campo CNPJ é obrigatório")]
        public int CNPj { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "* O Campo endereço é obrigatório")]
        public string Endereco { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "* O Campo numero é obrigatório")]
        public int Numero { get; set; }

        
        [Required(ErrorMessage = "* O Campo Bairro é obrigatório")]
        public string Bairro { get; set; }

        
        [Required(ErrorMessage = "* O Campo complemento é obrigatório")]
        public string Complemento { get; set; }

        
        [Required(ErrorMessage = "* O Campo CEP é obrigatório")]
        public int CEP { get; set; }

        
        [Required(ErrorMessage = "* O Campo Estado é obrigatório")]
        public string Estado { get; set; }

        
        [Required(ErrorMessage = "* O Campo Cidade é obrigatório")]
        public string Cidade { get; set; }

       
        [Required(ErrorMessage = "* O Campo Telefone é obrigatório")]
        public int Telefone { get; set; }

        public string Email { get; set; }
        public IFormFile Photo { get; set; }
    }
}
