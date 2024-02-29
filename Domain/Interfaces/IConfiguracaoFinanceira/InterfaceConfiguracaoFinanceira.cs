using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IConfiguracaoFinanceira;

public interface InterfaceConfiguracaoFinanceira : InterfaceGeneric<ConfiguracaoFinanceira>
{
    Task<IList<ConfiguracaoFinanceira>> ListarConfiguracaoFinanceiraClinica(int idClinica);
}
