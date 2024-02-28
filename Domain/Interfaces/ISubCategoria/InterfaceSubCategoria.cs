using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.ISubCategoria;

public interface InterfaceSubCategoria : InterfaceGeneric<SubCategoria>
{
    Task<IList<SubCategoria>> ListarSubCategoriaFinanceiras(int idCategoriaFinanceira);
}
