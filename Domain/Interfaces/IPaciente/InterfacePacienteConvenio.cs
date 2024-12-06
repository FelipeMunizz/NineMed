using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IPaciente;

public interface InterfacePacienteConvenio : InterfaceGeneric<PacienteConvenio>
{
    Task<IList<PacienteConvenio>> ListaConveniosPaciente(int idPaciente);
}
