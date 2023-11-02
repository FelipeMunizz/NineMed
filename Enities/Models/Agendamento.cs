using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Agendamento
{
    public int Id { get; set; }
    public DateTime DataAgendamento { get; set; }
    public TimeSpan HorarioInicio { get; set; }
    public TimeSpan HorarioFim { get; set; }
    public RepeticaoAgendamento Repeticao { get; set; }
    public SituacaoAgendamento SituacaoAgendamento { get; set; }
    public bool Lembrete { get; set; }
    public string Observacao { get; set; }

    [ForeignKey("PacienteAgendamento")]
    public int IdPacienteAgendamento { get; set; }

    [NotMapped]
    public virtual PacienteAgendamento PacienteAgendamento { get; set; }

    [ForeignKey("ProfissionalSaudeAgendamento")]
    public int IdProfissionalSaudeAgendamento { get; set; }

    [NotMapped]
    public virtual ProfissionalSaudeAgendamento ProfissionalSaudeAgendamento { get; set; }
}
