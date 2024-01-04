using Domain.Interfaces.IPaciente;
using Entities.Models;
using Infra.Repositorio.Generico;

namespace Infra.Repositorio.PacienteRepositorio;

public class PacienteFamiliarRepoistory : RepositorioGenerico<PacienteFamiliar>, InterfacePacienteFamiliar
{
    public Task<IList<PacienteFamiliar>> ListaEnderecosFamiliar(int idPaciente)
    {
        throw new NotImplementedException();
    }
}
