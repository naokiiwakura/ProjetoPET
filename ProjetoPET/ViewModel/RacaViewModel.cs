using ProjetoPET.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.ViewModel
{
    public class RacaViewModel : Pet
    {
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Raça")]
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public string Raca { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage ="* Campo Obrigatório")]
        public int Idade { get; set; }

        [Required(ErrorMessage ="* Campo Obrigatório")]
        public string Sexo { get; set; }

        [Required(ErrorMessage ="* Campo Obrigatório")]
        public int Telefone { get; set; }
    }
}
