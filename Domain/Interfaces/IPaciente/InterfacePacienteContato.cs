using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IPaciente;

public interface InterfacePacienteContato : InterfaceGeneric<ContatoPaciente>
{
    Task<IList<ContatoPaciente>> ListaContatosPaciente(int idPaciente);
}
