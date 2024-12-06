using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class AnexosAtendimento
{
    public int Id { get; set; }
    public byte[] Base64Anexo { get; set; }

    [ForeignKey("Atendimento")]
    public int IdAtendimento { get; set; }
    [JsonIgnore]
    public virtual Atendimento? Atendimento { get; set; }
}
