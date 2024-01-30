using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IAtendimento;

public interface InterfaceAnexosAtendimento : InterfaceGeneric<AnexosAtendimento>
{
    Task<IList<AnexosAtendimento>> ListaAnexosAtendimento(int idAtendimento);
}
