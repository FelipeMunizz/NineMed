using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Paciente : Base
{
    public DateTime DataNascimento { get; set; }
    public EstadoCivil EstadoCivil { get; set; }
    public string? RG { get; set; }
    public string? CPF { get; set; }
    public string? Profissao { get; set; }

    [ForeignKey("PacienteFamiliar")]
    public int IdPacienteFamiliar { get; set; }
    public virtual PacienteFamiliar? PacienteFamiliar { get; set; }

    [ForeignKey("PacienteConvenio")]
    public int IdPacienteConvenio { get; set; }
    public virtual PacienteConvenio? PacienteConvenio { get; set; }

    [ForeignKey("Clinica")]
    public int IdClinica { get; set; }
    public virtual Clinica Clinica { get; set; }
}
