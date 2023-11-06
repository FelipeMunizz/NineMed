using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Convenio : Base
{
    public string? RegistroAns { get; set; }
    public string? NomeFantasia { get; set; }
    public bool Ativo { get; set; }

    [ForeignKey("Clinica")]
    public int IdClinica { get; set; }
    public virtual Clinica? Clinica { get; set; }
}
