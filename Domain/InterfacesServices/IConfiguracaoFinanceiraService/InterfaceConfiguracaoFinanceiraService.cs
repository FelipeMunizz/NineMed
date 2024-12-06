using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.IConfiguracaoFinanceiraService;

public interface InterfaceConfiguracaoFinanceiraService
{
    Task<RetornoGenerico<ConfiguracaoFinanceira>> AdicionarConfiguracaoFinanceira(ConfiguracaoFinanceira configuracaoFinanceira);
    Task AtualizarConfiguracaoFinanceira(ConfiguracaoFinanceira configuracaoFinanceira);
    Task<IList<ConfiguracaoFinanceira>> ListarConfiguracaoFinanceiraClinica(int idClinica);
    Task<ConfiguracaoFinanceira> ObterConfiguracaoFinanceira(int idConfiguracaoFinanceira);
    Task<RetornoGenerico<object>> DeletarConfiguracaoFinanceira(int idConfiguracaoFinanceira);
}
