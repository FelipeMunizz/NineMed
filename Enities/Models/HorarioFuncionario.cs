using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class HorarioFuncionario
{
    public int Id { get; set; }
    public DateTime DataHorario {  get; set; }
    [ForeignKey("Funcionario")]
    public int IdFuncionario { get; set; }
    public virtual Funcionario? Funcionario { get; set; }

}
