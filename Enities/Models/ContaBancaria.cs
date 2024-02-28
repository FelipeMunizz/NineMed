using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class ContaBancaria : Base
{
    public decimal SaldoInicial { get; set; }
    public DateTime DataSaldo { get; set; }
    public string? Agencia { get; set; }
    public string? Conta {  get; set; }

    [ForeignKey("Banco")]
    public int IdBanco { get; set; }
    [JsonIgnore]
    public virtual Banco? Banco { get; set; }
}
