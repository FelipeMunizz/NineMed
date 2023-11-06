using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class ContatoPaciente : Contato
{
    [ForeignKey("Paciente")]
    public int IdPaciente { get; set; }
    public virtual Paciente? Paciente { get; set; }
}
