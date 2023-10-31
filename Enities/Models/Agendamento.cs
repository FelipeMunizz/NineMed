using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Agendamento
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public string HorarioInicio { get; set; }
    public string HorarioFim { get; set; }
    public RepeticaoAgendamento Repeticao { get; set; }
    public bool Lembrete { get; set; }
    public string Observacao { get; set; }

    [ForeignKey("Paciente")]
    public int IdPaciente { get; set; }
    public virtual Paciente Paciente { get; set; }
}
