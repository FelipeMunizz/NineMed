using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class ConfiguracaoClinica
{
    public int Id { get; set; }
    public TimeOnly HorarioAbertura { get; set; }
    public TimeOnly HorarioFechamento { get; set; }
    public string? IntervaloAgendaPadrao { get; set; }
    public bool FuncionaFeriados { get; set; }
    public bool ControlaEstoque { get; set; }
    public string? NumeroNota { get; set; }
    public string? CNAE { get; set; }
    [ForeignKey("Clinica")]
    [Column(Order = 1)]
    public int IdClinica { get; set; }
    [JsonIgnore]
    public virtual Clinica? Clinica { get; set; }
}
