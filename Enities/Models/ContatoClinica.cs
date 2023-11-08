using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class ContatoClinica : Contato
{
    [ForeignKey("Clinica")]
    public int IdClinica { get; set; }
    public virtual Clinica? Clinica { get; set; }
}
