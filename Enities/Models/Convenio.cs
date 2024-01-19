using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class Convenio : Base
{
    public string? RegistroAns { get; set; }
    public string? NomeFantasia { get; set; }
    public bool Ativo { get; set; }

    [ForeignKey("Clinica")]
    public int IdClinica { get; set; }
    [JsonIgnore]
    public virtual Clinica? Clinica { get; set; }
}
