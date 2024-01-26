using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class Atendimento
{
    public int Id { get; set; }
    public string? QueixaPrincipal { get; set; }
    public string? HistoriaMolestiaAtual {  get; set; }
    public string? HistoricoAntecedentes { get; set; }
    public string? ExameFisico { get; set; }
    public decimal? IMC { get; set; }
    public string? Diagnostico { get; set; }
    public string? Conduta { get; set;}

    [ForeignKey("Paciente")]
    public int IdPaciente { get; set; }
    [JsonIgnore]
    public virtual Paciente? Paciente { get; set; }

    [ForeignKey("Funcionario")]
    public int IdFuncionario { get; set; }
    [JsonIgnore]
    public virtual Funcionario? Funcionario { get; set; }
}
