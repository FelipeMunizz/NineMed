using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class Convenio : Base
{
    public string? RegistroAns { get; set; }
    public string? NomeFantasia { get; set; }
    public bool Ativo { get; set; }
    public string? Executante { get; set; }
    public string? CodOperadora { get; set; }
    public string? VersaoTISS { get; set; }
    public string? ProximoLote {  get; set; }
    public string? ProximaGuia { get; set; }
    public bool SADT {  get; set; }

    [ForeignKey("Clinica")]
    public int IdClinica { get; set; }
    [JsonIgnore]
    public virtual Clinica? Clinica { get; set; }
}
