using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IAtendimento;

public interface InterfaceExameAtendimento : InterfaceGeneric<ExameAtendimento>
{
    Task<IList<ExameAtendimento>> ListaAxamesAtendimento(int idAtendimento);
}
