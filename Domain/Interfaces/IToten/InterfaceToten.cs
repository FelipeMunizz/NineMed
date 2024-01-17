using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IToten;

public interface InterfaceToten : InterfaceGeneric<Toten>
{
    Task<List<Toten>> ListaTotensClinica(int idClinica);
}
