using Domain.Interfaces.IPaciente;
using Entities.Models;
using Infra.Repositorio.Generico;

namespace Infra.Repositorio.PacienteRepositorio;

public class PacienteContatoRepository : RepositorioGenerico<ContatoPaciente>, InterfacePacienteContato
{
    public Task<IList<ContatoPaciente>> ListaContatosPaciente(int idPaciente)
    {
        throw new NotImplementedException();
    }
}
