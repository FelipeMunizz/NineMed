using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class FormaPagamento : Base
{
    public string TipoValor { get; set; }
    public bool UtilizaTef {  get; set; }

    [ForeignKey("Clinica")]
    [JsonIgnore]
    public int IdClinica { get; set; }
    public virtual Clinica? Clinica { get; set; }
}
