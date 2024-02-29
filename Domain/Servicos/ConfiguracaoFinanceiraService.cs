using Domain.Interfaces.IConfiguracaoFinanceira;
using Domain.InterfacesServices.ICategoriaFinanceiraService;
using Domain.InterfacesServices.IConfiguracaoFinanceiraService;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class ConfiguracaoFinanceiraService : InterfaceConfiguracaoFinanceiraService
{
    private readonly InterfaceConfiguracaoFinanceira _repository;

    public ConfiguracaoFinanceiraService(InterfaceConfiguracaoFinanceira repository)
    {
        _repository = repository;
    }

    public async Task<RetornoGenerico<ConfiguracaoFinanceira>> AdicionarConfiguracaoFinanceira(ConfiguracaoFinanceira ConfiguracaoFinanceira)
    {
        ConfiguracaoFinanceira = await _repository.Add(ConfiguracaoFinanceira);

        if (ConfiguracaoFinanceira.Id == 0)
            return new RetornoGenerico<ConfiguracaoFinanceira>
            {
                Success = false,
                Message = "Não foi possível adicionar o Configuracao Financeira"
            };
        else
            return new RetornoGenerico<ConfiguracaoFinanceira>
            {
                Success = true,
                Message = "Configuracao Financeira adicionado com sucesso",
                Result = ConfiguracaoFinanceira
            };
    }

    public async Task AtualizarConfiguracaoFinanceira(ConfiguracaoFinanceira ConfiguracaoFinanceira)
    {
        await _repository.Update(ConfiguracaoFinanceira);
    }

    public async Task<RetornoGenerico<object>> DeletarConfiguracaoFinanceira(int idConfiguracaoFinanceira)
    {
        ConfiguracaoFinanceira ConfiguracaoFinanceira = await _repository.GetEntityById(idConfiguracaoFinanceira);
        if (ConfiguracaoFinanceira == null)
            return new RetornoGenerico<object>
            {
                Success = false,
                Message = "Não foi possível localizar o Configuracao Financeira"
            };

        await _repository.Delete(ConfiguracaoFinanceira);

        return new RetornoGenerico<object> { Success = true, Message = "Configuracao Financeira Deletado com sucesso" };
    }

    public async Task<IList<ConfiguracaoFinanceira>> ListarConfiguracaoFinanceiraClinica(int idClinica)
    {
        return await _repository.ListarConfiguracaoFinanceiraClinica(idClinica);
    }

    public async Task<ConfiguracaoFinanceira> ObterConfiguracaoFinanceira(int idConfiguracaoFinanceira)
    {
        return await _repository.GetEntityById(idConfiguracaoFinanceira);
    }
}
