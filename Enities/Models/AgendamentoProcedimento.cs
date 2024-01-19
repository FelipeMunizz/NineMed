using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class AgendamentoProcedimento
{
    public int Id { get; set; }
    public int Quantidade { get; set; }

    [ForeignKey("Agendamento")]
    public int IdAgendamento { get; set; }
    [JsonIgnore]
    public virtual Agendamento? Agendamento { get; set; }


    [ForeignKey("Procedimento")]
    public int IdProcedimento { get; set; }
    [JsonIgnore]
    public virtual Procedimento? Procedimento { get; set; }

    public decimal ValorTotal { get; set; }

}
