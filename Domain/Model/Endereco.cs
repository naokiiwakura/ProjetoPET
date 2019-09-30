
namespace Domain.Model
{
    public class Endereco : EntityBase
    {
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
    }
}
