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
    public bool Finalizado { get; set; }

    [ForeignKey("Agendamento")]
    public int IdAgendamento { get; set; }
    [JsonIgnore]
    public virtual Agendamento? Agendamento { get; set; }
}
