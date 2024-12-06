using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class SubCategoria : Base
{
    [ForeignKey("CategoriaFinanceira")]
    public int IdCategoriaFinanceira { get; set; }
    [JsonIgnore]
    public virtual CategoriaFinanceira? CategoriaFinanceira { get; set; }
}
