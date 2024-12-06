using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IAtendimento;

public interface InterfaceAtestadoAtendimento : InterfaceGeneric<AtestadoAtendimento>
{
    Task<IList<AtestadoAtendimento>> ListaAtestadoAtendimento(int idAtendimento);
}
