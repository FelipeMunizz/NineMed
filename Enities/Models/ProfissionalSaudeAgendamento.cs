using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class ProfissionalSaudeAgendamento
{
    public int Id { get; set; }
    [ForeignKey("UsuarioClinica")]
    public int IdUsuarioClinica { get; set; }
    [NotMapped]
    public virtual UsuarioClinica UsuarioClinica { get; set; }
}
