using Entities.Enums;

namespace Entities.Models
{
    public class SenhaToten
    {
        public int ID { get; set; }
        public string? SenhaPainel { get; set; }
        public TipoAtendimento TipoAtendimento { get; set; }
        public StatusAtendimento StatusAtendimento { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public DateTime DataHoraAtualizacao { get; set; }
    }

}
