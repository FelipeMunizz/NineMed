using Domain.Interfaces.IPaciente;
using Entities.Models;
using Infra.Repositorio.Generico;

namespace Infra.Repositorio.PacienteRepositorio;

public class PacienteRepository : RepositorioGenerico<Paciente>, InterfacePaciente
{
}
