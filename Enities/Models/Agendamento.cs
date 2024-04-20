using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class Agendamento
{
    public int Id { get; set; }
    public DateTime DataAgendamento { get; set; }
    public TimeOnly HoraAgendamento { get; set; }
    public RepeticaoAgendamento Repeticao { get; set; }
    public SituacaoAgendamento SituacaoAgendamento { get; set; }
    public bool Lembrete { get; set; }
    public string? Observacao { get; set; }
    public int[] IdsProcedimento { get; set; }

    [ForeignKey("Clinica")]
    public int IdClinica { get; set; }

    [JsonIgnore]
    public virtual Clinica? Clinica { get; set; }

    [ForeignKey("Paciente")]
    public int IdPaciente { get; set; }
    [JsonIgnore]
    public virtual Paciente? Paciente { get; set; }

    [ForeignKey("Funcionario")]
    public int IdFuncionario { get; set; }
    [JsonIgnore]
    public virtual Funcionario? Funcionario { get; set; }

    [ForeignKey("Convenio")]
    public int IdConvenio { get; set; }
    [JsonIgnore]
    public virtual Convenio? Convenio { get; set; }
}
