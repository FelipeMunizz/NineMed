using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IAtendimento;

public interface InterfaceAtendimento : InterfaceGeneric<Atendimento>
{
    Task<IList<Atendimento>> ListaAtentedimentoPaciente(int idPaciente);
}
