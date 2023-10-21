using Enities.Enums;

namespace Enities.Models
{
    public class SenhaTotem
    {
        public int ID { get; set; }
        public string SenhaPainel { get; set; }
        public TipoAtendimento TipoAtendimento { get; set; }
        public StatusAtendimento StatusAtendimento { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public DateTime DataHoraAtualizacao { get; set; }
    }

}
