

namespace Domain.Model
{
    public class Cidade : EntityBase
    {
        public string Nome { get; set; }
        public Estado Estado { get; set; }
    }
}
