using Entities.Enums;
using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.ISubCategoriaService;

public interface InterfaceSubCategoriaService
{
    Task<RetornoGenerico<SubCategoria>> AdicionarSubCategoria(SubCategoria subCategoria);
    Task AtualizarSubCategoria(SubCategoria subCategoria);
    Task<IList<SubCategoria>> ListarSubCategoriaFinanceiras(int idCategoriaFinanceira);
    Task<IList<SubCategoria>> ListaSubCategoriaTipo(TipoLancamento tipo, int idClinica);
    Task<SubCategoria> ObterSubCategoria(int idSubCategoria);
    Task<RetornoGenerico<object>> DeletarSubCategoria(int idSubCategoria);
}
