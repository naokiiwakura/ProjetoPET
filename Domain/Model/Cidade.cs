

namespace Domain.Model
{
    public class Cidade : EntityBase
    {
        public string Nome { get; set; }
        public virtual Estado Estado { get; set; }
        public int EstadoId { get;set; }
    }
}
