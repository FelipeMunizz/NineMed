using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class AgendamentoProcedimento
{
    public int Id { get; set; }
    public int Quantidade { get; set; }

    [ForeignKey("Agendamento")]
    [JsonIgnore]
    public int IdAgendamento { get; set; }
    public virtual Agendamento? Agendamento { get; set; }


    [ForeignKey("Procedimento")]
    [JsonIgnore]
    public int IdProcedimento { get; set; }
    public virtual Procedimento? Procedimento { get; set; }

    public decimal ValorTotal { get; set; }

}
