using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class ProfissionaisSaudeConvenio
{
    public int Id { get; set; }
    [ForeignKey("Convenio")]
    public int IdConvenio { get; set; }
    [JsonIgnore]
    public virtual Convenio? Convenio { get; set; }

    [ForeignKey("Funcionario")]
    public int IdFuncionario { get; set; }
    [JsonIgnore]
    public virtual Funcionario? Funcionario { get; set; }
}
