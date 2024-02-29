using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.ICategoriaFinanceiraService;

public interface InterfaceCategoriaFinanceiraService
{
    Task<RetornoGenerico<CategoriaFinanceira>> AdicionarCategoriaFinanceira(CategoriaFinanceira categoriaFinanceira);
    Task AtualizarCategoriaFinanceira(CategoriaFinanceira categoriaFinanceira);
    Task<IList<CategoriaFinanceira>> ListarCategoriasFinanceiraClinica(int idClinica);
    Task<CategoriaFinanceira> ObterCategoriaFinanceira(int idCategoriaFinanceira);
    Task<RetornoGenerico<object>> DeletarCategoriaFinanceira(int idCategoriaFinanceira);
}
