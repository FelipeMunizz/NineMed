using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class EnderecoPaciente : Endereco
{
    public int Id { get; set; }
    [ForeignKey("Paciente")]
    public int IdPaciente { get; set; }
    public virtual Paciente Paciente { get; set; }
}
