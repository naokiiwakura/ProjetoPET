using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.Models
{
    public class TelaDeAdocao
    {
        [Key]
        public int Id { get; set; }
        public string Raca { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public decimal Preco { get; set; }
    }
}
