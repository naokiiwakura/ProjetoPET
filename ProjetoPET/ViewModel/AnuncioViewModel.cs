using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.ViewModel
{
    public class AnuncioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatório")]
        [Display(Name = "Descrição")]
        public string CorpoAnuncio { get; set; }

        [Required(ErrorMessage = "Uma foto é obrigatório")]
        public IFormFile Foto { get; set; }

        [Display(Name = "Imagem")]
        public string CaminhoDaFoto { get; set; }

        [Required(ErrorMessage = "Escolha um Tipo")]
        [Display(Name = "Tipo Anúncio")]
        public int TipoAnuncioId { get; set; }

        [Required(ErrorMessage = "Escolha um PET")]
        public int PetId { get; set; }

        [Display(Name = "Nome")]
        public string NomeDoPet { get; set; }

        [Required(ErrorMessage = "Digite o nome da rua")]
        public string Rua { get; set; }
        
        public int Numero { get; set; }

        [Required(ErrorMessage = "Digite seu CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Escolha uma cidade")]
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }

        [Required(ErrorMessage = "Escolha um Estado")]
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }

        public ICollection<string> Telefones { get; set; }
    }
}
