using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IConfiguracaoClinica;

public interface InterfaceConfiguracaoClinica : InterfaceGeneric<ConfiguracaoClinica>
{
    Task<ConfiguracaoClinica> ObterConfiguracaoClinica(int idClinica);
}
