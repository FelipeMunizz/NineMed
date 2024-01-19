using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class Convenio : Base
{
    public string? RegistroAns { get; set; }
    public string? NomeFantasia { get; set; }
    public bool Ativo { get; set; }

    [ForeignKey("Clinica")]
    [JsonIgnore]
    public int IdClinica { get; set; }
    public virtual Clinica? Clinica { get; set; }
}
