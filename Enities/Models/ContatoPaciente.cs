using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class ContatoPaciente : Contato
{
    [ForeignKey("Paciente")]
    public int Id { get; set; }
    [NotMapped]
    public virtual Paciente Paciente { get; set; }
}
