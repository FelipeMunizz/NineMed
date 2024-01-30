using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IAtendimento;

public interface InterfacePrescricaoAtendimento : InterfaceGeneric<PrescricaoAtendimento>
{
    Task<IList<PrescricaoAtendimento>> ListaPrescricaoAtendimento(int idAtendimento);
}
