using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.ICentroCustoService;

public interface InterfaceCentroCustoService
{
    Task<RetornoGenerico<CentroCusto>> AdicionarCentroCusto(CentroCusto centroCusto);
    Task AtualizarCentroCusto(CentroCusto centroCusto);
    Task<IList<CentroCusto>> ListarCentroCustoClinica(int idClinica);
    Task<CentroCusto> ObterCentroCusto(int idCentroCusto);
    Task<RetornoGenerico<object>> DeletarCentroCusto(int idCentroCusto);
}
