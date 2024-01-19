using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models;

public class Funcionario : Base
{
    public string Email { get; set; }
    public bool ProfissionalSaude { get; set; }
    public PerfilUsuario Perfil { get; set; }
    public string? RegistroProfissional { get; set; }
    public string? Especialidade { get; set; }
    [ForeignKey("Clinica")]
    public int IdClinica { get; set; }
    [JsonIgnore]
    public virtual Clinica? Clinica { get; set; }
}
