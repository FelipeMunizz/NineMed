using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class FormaPagamento : Base
{
    public string TipoValor { get; set; }
    public bool UtilizaTef {  get; set; }

    [ForeignKey("Clinica")]
    public int IdClinica { get; set; }
    public virtual Clinica? Clinica { get; set; }
}
