using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class PacienteFamiliar : Base
{
    public string GrauParentesco { get; set; }
    public string Telefone { get; set; }

    [ForeignKey("Paciente")]
    public int IdPaciente { get; set; }
    public virtual Paciente Paciente { get; set; }
}
