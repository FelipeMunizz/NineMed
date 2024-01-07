using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class AgendamentoPagamento
{
    public int Id { get; set; }

    [ForeignKey("Agendamento")]
    public int IdAgendamento { get; set; }
    public virtual Agendamento Agendamento { get; set; }

    [ForeignKey("FormaPagamento")]
    public int IdFormaPagamento { get; set; }
    public virtual FormaPagamento FormaPagamento { get; set; }

    public decimal Valor { get; set; }
    public decimal Troco { get; set; }
}
