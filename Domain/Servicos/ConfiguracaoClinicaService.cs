using Domain.Interfaces.IConfiguracaoClinica;
using Domain.InterfacesServices.IConfiguracaoClinicaService;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class ConfiguracaoClinicaService : InterfaceConfiguracaoClinicaService
{
    private readonly InterfaceConfiguracaoClinica _repositorio;

    public ConfiguracaoClinicaService(InterfaceConfiguracaoClinica repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<RetornoGenerico<ConfiguracaoClinica>> AdicionarConfiguracaoClinica(ConfiguracaoClinica configuracaoClinica)
    {
        configuracaoClinica = await _repositorio.Add(configuracaoClinica);
        if (configuracaoClinica.Id > 0)
            return new RetornoGenerico<ConfiguracaoClinica>
            {
                Success = true,
                Message = "Configuração adicionada com sucesso",
                Result = configuracaoClinica
            };
        else
            return new RetornoGenerico<ConfiguracaoClinica>
            {
                Success = false,
                Message = "Erro ao adicionar configuração"
            };

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
