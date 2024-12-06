using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class ContatoPaciente : Contato
{
    [ForeignKey("Paciente")]
    public int IdPaciente { get; set; }
    [JsonIgnore]
    public virtual Paciente? Paciente { get; set; }
}
