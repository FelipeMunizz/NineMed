using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class Lancamento
{
    public int Id { get; set; }
    public TipoLancamento Tipo {  get; set; }
    public decimal Valor { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataLancamento { get; set; }
    public DateTime DataVencimento { get; set; }

    [ForeignKey("Paciente")]
    public int? IdPaciente { get; set; }
    [JsonIgnore]
    public virtual Paciente? Paciente { get; set; }

    [ForeignKey("Funcionario")]
    public int IdFuncionario { get; set; }
    [JsonIgnore]
    public virtual Funcionario? Funcionario { get; set; }

    [ForeignKey("Convenio")]
    public int? IdConvenio { get; set; }
    [JsonIgnore]
    public virtual Convenio? Convenio { get; set; }

    [ForeignKey("Procedimento")]
    public int? IdProcedimento { get; set; }
    [JsonIgnore]
    public virtual Procedimento? Procedimento { get; set; }

    [ForeignKey("SubCategoria")]
    public int IdSubCategoria { get; set; }
    [JsonIgnore]
    public virtual SubCategoria? SubCategoria { get; set; }

    [ForeignKey("ContaBancaria")]
    public int IdContaBancaria { get; set; }
    [JsonIgnore]
    public virtual ContaBancaria? ContaBancaria { get; set; }

    [ForeignKey("FormaPagamento")]
    public int IdFormaPagamento { get; set; }
    [JsonIgnore]
    public virtual FormaPagamento? FormaPagamento { get; set; }

    [ForeignKey("CentroCusto")]
    public int? IdCentroCusto { get; set; }
    [JsonIgnore]
    public virtual CentroCusto? CentroCusto { get; set; }

    [ForeignKey("Clinica")]
    public int IdClinica { get; set; }
    [JsonIgnore]
    public virtual Clinica? Clinica { get; set; }
}
