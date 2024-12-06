using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IPaciente;

public interface InterfacePacienteFamiliar : InterfaceGeneric<PacienteFamiliar>
{
    Task<IList<PacienteFamiliar>> ListaFamiliaresPaciente(int idPaciente);
}
