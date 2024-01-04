using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IPaciente;

public interface InterfacePacienteEndereco : InterfaceGeneric<EnderecoPaciente>
{
    Task<IList<EnderecoPaciente>> ListaEnderecosPaciente(int idPaciente);
}
