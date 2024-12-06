using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IPaciente;

public interface InterfacePacienteProntuario : InterfaceGeneric<PacienteProntuario>
{
    Task<PacienteProntuario> ObtemPacienteProntuario(int idPaciente);
    Task<object> ObtemProntuarioTelaAtendimento(int idPaciente);
}
