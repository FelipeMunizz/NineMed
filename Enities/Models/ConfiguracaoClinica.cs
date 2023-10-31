using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class ConfiguracaoClinica
{
    public int Id { get; set; }
    public DateTime HorarioAbertura { get; set; }
    public DateTime HorarioFechamento { get; set; }
    public DiasSemana DiaInicio { get; set; }
    public DiasSemana DiaFim { get; set; }
    public string IntervaloAgenda { get; set; }
    public bool FuncionaFeriados { get; set; }
    public bool ControlaEstoque {  get; set; }
    [ForeignKey("Clinica")]
    [Column(Order = 1)]
    public int IdClinica { get; set; }
    public virtual Clinica Clinica { get; set; }
}
