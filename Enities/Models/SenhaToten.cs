using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class SenhaToten
{
    public int Id { get; set; }
    [StringLength(50)]
    public string? SenhaPainel { get; set; }
    public TipoAtendimento TipoAtendimento { get; set; }
    public StatusAtendimento StatusAtendimento { get; set; }
    public DateTime DataHoraCriacao { get; set; }
    public DateTime DataHoraAtualizacao { get; set; }

    [ForeignKey("Toten")]
    [Column(Order = 1)]
    public int IdToten { get; set; }
    [JsonIgnore]
    public virtual Toten? Toten { get; set; }
}
