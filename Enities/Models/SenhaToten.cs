using Entities.Enums;

namespace Entities.Models;

public class SenhaToten
{
    public string? SenhaPainel { get; set; }
    public TipoAtendimento TipoAtendimento { get; set; }
    public StatusAtendimento StatusAtendimento { get; set; }
    public DateTime DataHoraCriacao { get; set; }
    public DateTime DataHoraAtualizacao { get; set; }
    public int IdToten { get; set; }
}
