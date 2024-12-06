using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class ContatoClinica : Contato
{
    [ForeignKey("Clinica")]
    public int IdClinica { get; set; }
    [JsonIgnore]
    public virtual Clinica? Clinica { get; set; }
}
