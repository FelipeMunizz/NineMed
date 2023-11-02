using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class ContatoClinica : Contato
{
    [ForeignKey("Clinica")]
    public int Id { get; set; }
    [NotMapped]
    public virtual Clinica Clinica { get; set; }
}
