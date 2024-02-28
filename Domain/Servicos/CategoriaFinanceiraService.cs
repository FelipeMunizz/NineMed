using Domain.Interfaces.ICategoriaFinanceira;
using Domain.InterfacesServices.ICategoriaFinanceiraService;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class CategoriaFinanceiraService : InterfaceCategoriaFinanceiraService
{
    private readonly InterfaceCategoriaFinanceira _repository;

    public CategoriaFinanceiraService(InterfaceCategoriaFinanceira repository)
    {
        _repository = repository;
    }

    public async Task<RetornoGenerico<CategoriaFinanceira>> AdicionarCategoriaFinanceira(CategoriaFinanceira categoriaFinanceira)
    {
        categoriaFinanceira = await _repository.Add(categoriaFinanceira);

        if (categoriaFinanceira.Id == 0)
            return new RetornoGenerico<CategoriaFinanceira>
            {
                Success = false,
                Message = "Não foi possível adicionar o Categoria Financeira"
            };
        else
            return new RetornoGenerico<CategoriaFinanceira>
            {
                Success = true,
                Message = "Categoria Financeira adicionado com sucesso",
                Result = categoriaFinanceira
            };
    }

    public async Task AtualizarCategoriaFinanceira(CategoriaFinanceira categoriaFinanceira)
    {
        await _repository.Update(categoriaFinanceira);
    }

    public async Task<RetornoGenerico<object>> DeletarCategoriaFinanceira(int idCategoriaFinanceira)
    {
        CategoriaFinanceira CategoriaFinanceira = await _repository.GetEntityById(idCategoriaFinanceira);
        if (CategoriaFinanceira == null)
            return new RetornoGenerico<object>
            {
                Success = false,
                Message = "Não foi possível localizar o Categoria Financeira"
            };

        await _repository.Delete(CategoriaFinanceira);

        return new RetornoGenerico<object> { Success = true, Message = "Categoria Financeira Deletado com sucesso" };
    }

    public async Task<IList<CategoriaFinanceira>> ListarCategoriasFinanceiraClinica(int idClinica)
    {
        return await _repository.ListarCategoriasFinanceiraClinica(idClinica);
    }

    public async Task<CategoriaFinanceira> ObterCategoriaFinanceira(int idCategoriaFinanceira)
    {
        return await _repository.GetEntityById(idCategoriaFinanceira);
    }
}
