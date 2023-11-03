using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class EnderecoClinica : Endereco
{
    public int Id { get; set; }
    [ForeignKey("Clinica")]
    public int IdClinica { get; set; }
    public virtual Clinica Clinica { get; set; }
}
