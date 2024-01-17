using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class ConfiguracaoClinica
{
    public int Id { get; set; }
    public TimeOnly HorarioAbertura { get; set; }
    public TimeOnly HorarioFechamento { get; set; }
    public string IntervaloAgendaPadrao { get; set; }
    public bool FuncionaFeriados { get; set; }
    public bool ControlaEstoque { get; set; }
    [ForeignKey("Clinica")]
    [Column(Order = 1)]
    public int IdClinica { get; set; }
    public virtual Clinica? Clinica { get; set; }
}
