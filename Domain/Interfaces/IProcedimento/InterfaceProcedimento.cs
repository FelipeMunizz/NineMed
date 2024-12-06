using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IProcedimento;

public interface InterfaceProcedimento : InterfaceGeneric<Procedimento>
{
    Task<IList<Procedimento>> ListaProcedimentoClinica(int idClinica);
}
