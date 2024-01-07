using Domain.Interfaces.IConfiguracaoClinica;
using Domain.InterfacesServices.IConfiguracaoClinicaService;
using Entities.Models;

namespace Domain.Servicos;

public class ConfiguracaoClinicaService : InterfaceConfiguracaoClinicaService
{
    private readonly InterfaceConfiguracaoClinica _repositorio;

    public ConfiguracaoClinicaService(InterfaceConfiguracaoClinica repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task AdicionarConfiguracaoClinica(ConfiguracaoClinica configuracaoClinica)
    {
        await _repositorio.Add(configuracaoClinica);
    }

    public async Task AtualizarConfiguracaoClinica(ConfiguracaoClinica configuracaoClinica)
    {
        await _repositorio.Update(configuracaoClinica);
    }

    public async Task DeletarConfiguracaoClinica(int idConfiguracaoClinica)
    {
        ConfiguracaoClinica configuracaoClinica = await _repositorio.GetEntityById(idConfiguracaoClinica);
        await _repositorio.Delete(configuracaoClinica);
    }
}
