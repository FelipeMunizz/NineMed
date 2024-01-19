using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class EnderecoPaciente : Endereco
{
    public int Id { get; set; }
    [ForeignKey("Paciente")]
    public int IdPaciente { get; set; }
    [JsonIgnore]
    public virtual Paciente? Paciente { get; set; }
}
