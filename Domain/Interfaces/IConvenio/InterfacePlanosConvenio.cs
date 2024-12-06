using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IConvenio;

public interface InterfacePlanosConvenio : InterfaceGeneric<PlanosConvenio>
{
    Task<IList<PlanosConvenio>> ListaPlanoConvenios(int idConvenio);
}
