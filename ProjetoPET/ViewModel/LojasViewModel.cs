using Domain.Model;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "CNPJ")]
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
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }
        [Required(ErrorMessage = "* O Campo Cidade é obrigatório")]
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }
        [Required(ErrorMessage = "* O Campo Telefone é obrigatório")]
        public int Telefone { get; set; }
        public string Email { get; set; }
        public IFormFile Photo { get; set; }
        public string CaminhoDaFoto { get; set; }
    }
}