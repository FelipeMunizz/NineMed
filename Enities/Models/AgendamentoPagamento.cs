using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class AgendamentoPagamento
{
    public int Id { get; set; }

    [ForeignKey("Agendamento")]
    public int IdAgendamento { get; set; }
    [JsonIgnore]
    public virtual Agendamento? Agendamento { get; set; }

    [ForeignKey("FormaPagamento")]
    public int IdFormaPagamento { get; set; }
    [JsonIgnore]
    public virtual FormaPagamento? FormaPagamento { get; set; }

    public decimal Valor { get; set; }
    public decimal Troco { get; set; }
    public decimal Desconto { get; set; }
    public decimal Acrescimo { get; set; }
}
