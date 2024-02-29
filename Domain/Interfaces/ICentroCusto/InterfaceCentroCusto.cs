using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.ICentroCusto;

public interface InterfaceCentroCusto : InterfaceGeneric<CentroCusto>
{
    Task<IList<CentroCusto>> ListarCentroCustoClinica(int idClinica);
}
