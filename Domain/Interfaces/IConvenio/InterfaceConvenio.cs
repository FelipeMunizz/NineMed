using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IConvenio;

public interface InterfaceConvenio : InterfaceGeneric<Convenio>
{
    Task<IList<Convenio>> ListaConveniosClinica(int idClinica);
}
