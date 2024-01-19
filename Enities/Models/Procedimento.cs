using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class Procedimento : Base
{
    public decimal Preco { get; set; }
    public int Duracao { get; set; }
    public string? CodTribMunicipio { get; set; }

    [ForeignKey("Clinica")]
    [JsonIgnore]
    public int IdClinica { get; set; }
    public virtual Clinica? Clinica { get; set; }
}
