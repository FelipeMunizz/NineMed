using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Toten : Base
{
    [ForeignKey("Clinica")]
    public int IdClinica { get; set; }
    public virtual Clinica Clinica { get; set; }
}
