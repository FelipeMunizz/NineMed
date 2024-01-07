using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IToten;

public interface InterfaceToten : InterfaceGeneric<Toten>
{
    Task<IList<Toten>> ListaTotensClinica(int idClinica);
}
