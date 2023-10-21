using Enities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Enities.Models
{
    public class SenhaToten
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string? SenhaPainel { get; set; }
        public TipoAtendimento TipoAtendimento { get; set; }
        public StatusAtendimento StatusAtendimento { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public DateTime DataHoraAtualizacao { get; set; }
    }

}
