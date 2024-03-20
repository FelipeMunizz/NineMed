using Domain.Interfaces.Generics;
using Entities.Enums;
using Entities.Models;

namespace Domain.Interfaces.ISubCategoria;

public interface InterfaceSubCategoria : InterfaceGeneric<SubCategoria>
{
    Task<IList<SubCategoria>> ListarSubCategoriaFinanceiras(int idCategoriaFinanceira);
    Task<IList<SubCategoria>> ListaSubCategoriaTipo(TipoLancamento tipo, int idClinica);
}
