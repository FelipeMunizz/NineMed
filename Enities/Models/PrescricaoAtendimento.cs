using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class PrescricaoAtendimento
{
    public int Id { get; set; }
    public TipoPrescricao TipoPrescricao { get; set; }
    public string ItemReceita { get; set; }
    
    [ForeignKey("Atendimento")]
    public int IdAtendimento { get; set; }
    [JsonIgnore]
    public virtual Atendimento? Atendimento { get; set; }
}
