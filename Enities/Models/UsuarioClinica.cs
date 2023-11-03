using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class UsuarioClinica
{
    public int Id { get; set; }
    public string Email { get; set; }
    public PerfilUsuario Perfil { get; set; }
    public string RegistroProfissional { get; set; }
    public string Especialidade { get; set; }
    [ForeignKey("Clinica")]
    public int IdClinica { get; set; }
    public virtual Clinica Clinica { get; set; }
}
