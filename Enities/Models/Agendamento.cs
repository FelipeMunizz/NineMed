using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Agendamento
{
    public int Id { get; set; }
    public DateTime DataAgendamento { get; set; }
    public RepeticaoAgendamento Repeticao { get; set; }
    public SituacaoAgendamento SituacaoAgendamento { get; set; }
    public bool Lembrete { get; set; }
    public string? Observacao { get; set; }
    public string IdProcedimento { get; set; }

    [ForeignKey("Paciente")]
    public int IdPaciente { get; set; }
    public virtual Paciente? Paciente { get; set; }

    [ForeignKey("Funcionario")]
    public int IdFuncionario { get; set; }
    public virtual Funcionario? Funcionario { get; set; }
}
