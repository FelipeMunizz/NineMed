using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class PlanosConvenio : Base
{

    [ForeignKey("Convenio")]
    [Column(Order = 1)]
    public int IdConvenio { get; set; }
    [JsonIgnore]
    public virtual Convenio? Convenio { get; set; }
}
