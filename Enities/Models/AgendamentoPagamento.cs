using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class AgendamentoPagamento
{
    public int Id { get; set; }

    [ForeignKey("Agendamento")]
    [JsonIgnore]
    public int IdAgendamento { get; set; }
    public virtual Agendamento? Agendamento { get; set; }

    [ForeignKey("FormaPagamento")]
    [JsonIgnore]
    public int IdFormaPagamento { get; set; }
    public virtual FormaPagamento? FormaPagamento { get; set; }

    public decimal Valor { get; set; }
    public decimal Troco { get; set; }
    public decimal Desconto { get; set; }
    public decimal Acrescimo { get; set; }
}
