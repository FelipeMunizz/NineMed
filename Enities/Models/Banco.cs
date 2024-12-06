using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class Banco : Base
{
    public string? CodBanco {  get; set; }

    [ForeignKey("Clinica")]
    public int IdClinica { get; set; }
    [JsonIgnore]
    public virtual Clinica? Clinica { get; set; }
}
