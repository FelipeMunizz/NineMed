using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class ContatoPaciente : Contato
{
    [ForeignKey("Paciente")]
    [JsonIgnore]
    public int IdPaciente { get; set; }
    public virtual Paciente? Paciente { get; set; }
}
