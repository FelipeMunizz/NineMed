using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IBanco;

public interface IBanco : InterfaceGeneric<Banco>
{
    Task<IList<Banco>> ListaBancosClinica(int idClinica);
}
