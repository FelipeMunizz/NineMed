using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class ConfiguracaoFinanceira
{
    public int Id { get; set; }

    [ForeignKey("Banco")]
    public int? IdBanco { get; set; }
    [JsonIgnore]
    public virtual Banco? Banco { get; set; }

    [ForeignKey("ContaBancaria")]
    public int? IdContaBancaria { get; set; }
    [JsonIgnore]
    public virtual ContaBancaria? ContaBancaria { get; set; }

    [ForeignKey("CentroCusto")]
    public int? IdCentroCusto { get; set; }
    [JsonIgnore]
    public virtual CentroCusto? CentroCusto { get; set; }

    [ForeignKey("FormaPagamento")]
    public int? IdFormaPagamento { get; set; }
    [JsonIgnore]
    public virtual FormaPagamento? FormaPagamento { get; set; }

    [ForeignKey("Clinica")]
    public int? IdClinica { get; set; }
    [JsonIgnore]
    public virtual Clinica? Clinica { get; set; }
}
