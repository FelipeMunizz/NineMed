using Domain.Interfaces.IPaciente;
using Entities.Models;
using Infra.Repositorio.Generico;

namespace Infra.Repositorio.PacienteRepositorio;

public class PacienteConvenioRepository : RepositorioGenerico<PacienteConvenio>, InterfacePacienteConvenio
{
    public Task<IList<PacienteConvenio>> ListaConveniosPaciente(int idPaciente)
    {
        throw new NotImplementedException();
    }
}
