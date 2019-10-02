using System;

namespace Domain.Model
{
    public class Evento : EntityBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }

    }
}
