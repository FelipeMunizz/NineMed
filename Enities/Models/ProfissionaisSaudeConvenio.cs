using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class ProfissionaisSaudeConvenio
{

    [ForeignKey("Convenio")]
    [Column(Order = 1)]
    public int IdConvenio { get; set; }
    [JsonIgnore]
    public virtual Convenio? Convenio { get; set; }

    [ForeignKey("Funcionario")]
    [Column(Order = 1)]
    public int IdFuncionario { get; set; }
    [JsonIgnore]
    public virtual Funcionario? Funcionario { get; set; }
}
