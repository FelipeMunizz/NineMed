using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class ContatoClinica : Contato
{
    [ForeignKey("Clinica")]
    [JsonIgnore]
    public int IdClinica { get; set; }
    public virtual Clinica? Clinica { get; set; }
}
