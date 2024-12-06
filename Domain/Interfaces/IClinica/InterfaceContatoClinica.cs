using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IClinica;

public interface InterfaceContatoClinica : InterfaceGeneric<ContatoClinica>
{
    Task<IList<ContatoClinica>> ContatosClinica(int idClinica);
}
