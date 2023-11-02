using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    [ForeignKey("Clinica")]
    [Column(Order = 1)]
    public int IdClinica { get; set; }
    [NotMapped]
    public virtual Clinica Clinica { get; set; }
}
