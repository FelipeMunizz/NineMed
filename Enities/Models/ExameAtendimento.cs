using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class ExameAtendimento
{
    public int Id { get; set; }
    public DateTime? Data { get; set; }
    public string Exame { get; set; }
    public int Quantidade { get; set; }

    [ForeignKey("Atendimento")]
    public int IdAtendimento { get; set; }
    [JsonIgnore]
    public virtual Atendimento? Atendimento { get; set; }
}
