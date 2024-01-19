using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class HorarioFuncionario
{
    public int Id { get; set; }
    public DateTime DataHorario {  get; set; }
    public TimeOnly TempoAgendado { get; set; }
    [ForeignKey("Funcionario")]
    public int IdFuncionario { get; set; }
    [JsonIgnore]
    public virtual Funcionario? Funcionario { get; set; }

}
