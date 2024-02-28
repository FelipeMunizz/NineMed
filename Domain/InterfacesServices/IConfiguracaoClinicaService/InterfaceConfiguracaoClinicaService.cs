using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.IConfiguracaoClinicaService;

public interface InterfaceConfiguracaoClinicaService
{
    Task<RetornoGenerico<ConfiguracaoClinica>> AdicionarConfiguracaoClinica(ConfiguracaoClinica clinica);
    Task AtualizarConfiguracaoClinica(ConfiguracaoClinica clinica);
    Task DeletarConfiguracaoClinica(int idConfiguracaoClinica);
}               
