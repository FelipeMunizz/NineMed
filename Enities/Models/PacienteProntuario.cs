using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class PacienteProntuario
{
    public int Id { get; set; }
    public string? AntecedenteClinico { get; set; }
    public string? AntecedenteCirurgico { get; set; }
    public string? AntecedenteFamiliares { get; set; }
    public string? Habitos { get; set; }
    public string? Alergias { get; set; }
    public string? MedicamentoUso { get; set; }

    [ForeignKey("Paciente")]
    public int IdPaciente { get; set; }
    [JsonIgnore]
    public virtual Paciente? Paciente { get; set; }
}
