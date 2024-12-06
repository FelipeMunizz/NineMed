using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class AtendimentoProcedimento
{
    public int Id { get; set; }
    public int Quantidade { get; set; }

    [ForeignKey("Atendimento")]
    public int IdAtendimento { get; set; }
    [JsonIgnore]
    public virtual Atendimento? Atendimento { get; set; }


    [ForeignKey("Procedimento")]
    public int IdProcedimento { get; set; }
    [JsonIgnore]
    public virtual Procedimento? Procedimento { get; set; }

    public decimal ValorTotal { get; set; }

}
