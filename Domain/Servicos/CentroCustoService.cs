using Domain.Interfaces.ICentroCusto;
using Domain.InterfacesServices.ICentroCustoService;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class CentroCustoService : InterfaceCentroCustoService
{
    private readonly InterfaceCentroCusto _repository;

    public CentroCustoService(InterfaceCentroCusto repository)
    {
        _repository = repository;
    }

    public async Task<RetornoGenerico<CentroCusto>> AdicionarCentroCusto(CentroCusto centroCusto)
    {
        centroCusto = await _repository.Add(centroCusto);

        if (centroCusto.Id == 0)
            return new RetornoGenerico<CentroCusto>
            {
                Success = false,
                Message = "Não foi possível adicionar o Centro Custo"
            };
        else
            return new RetornoGenerico<CentroCusto>
            {
                Success = true,
                Message = "Centro Custo adicionado com sucesso",
                Result = centroCusto
            };
    }

    public async Task AtualizarCentroCusto(CentroCusto centroCusto)
    {
        await _repository.Update(centroCusto);
    }

    public async Task<RetornoGenerico<object>> DeletarCentroCusto(int idCentroCusto)
    {
        CentroCusto CentroCusto = await _repository.GetEntityById(idCentroCusto);
        if (CentroCusto == null)
            return new RetornoGenerico<object>
            {
                Success = false,
                Message = "Não foi possível localizar o Centro Custo"
            };

        await _repository.Delete(CentroCusto);

        return new RetornoGenerico<object> { Success = true, Message = "Centro Custo Deletado com sucesso" };
    }

    public async Task<IList<CentroCusto>> ListarCentroCustoClinica(int idClinica)
    {
        return await _repository.ListarCentroCustoClinica(idClinica);
    }

    public async Task<CentroCusto> ObterCentroCusto(int idCentroCusto)
    {
        return await _repository.GetEntityById(idCentroCusto);
    }
}
