using Entities.Models;

namespace Domain.InterfacesServices.IConfiguracaoClinicaService;

public interface InterfaceConfiguracaoClinicaService
{
    Task AdicionarConfiguracaoClinica(ConfiguracaoClinica clinica);
    Task AtualizarConfiguracaoClinica(ConfiguracaoClinica clinica);
    Task DeletarConfiguracaoClinica(int idConfiguracaoClinica);
}               
