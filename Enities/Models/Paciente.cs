using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class Paciente : Base
{
    public DateTime DataNascimento { get; set; }
    public EstadoCivil EstadoCivil { get; set; }
    public string? RG { get; set; }
    public string? CPF { get; set; }
    public string? Profissao { get; set; }

    [ForeignKey("Clinica")]
    public int IdClinica { get; set; }
    [JsonIgnore]
    public virtual Clinica? Clinica { get; set; }
}
