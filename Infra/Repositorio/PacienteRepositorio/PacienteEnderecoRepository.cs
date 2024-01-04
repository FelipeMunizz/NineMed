using Domain.Interfaces.IPaciente;
using Entities.Models;
using Infra.Repositorio.Generico;

namespace Infra.Repositorio.PacienteRepositorio;

public class PacienteEnderecoRepository : RepositorioGenerico<EnderecoPaciente>, InterfacePacienteEndereco
{
    public Task<IList<EnderecoPaciente>> ListaEnderecosPaciente(int idPaciente)
    {
        throw new NotImplementedException();
    }
}
