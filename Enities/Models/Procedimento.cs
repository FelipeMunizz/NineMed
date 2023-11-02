using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Procedimento : Base
{
    public decimal Preco { get; set; }
    public int Duracao { get; set; }

    [ForeignKey("Clinica")]
    public int IdClinica { get; set; }
    [NotMapped]
    public virtual Clinica Clinica { get; set; }
}
