using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.ICategoriaFinanceira;

public interface InterfaceCategoriaFinanceira : InterfaceGeneric<CategoriaFinanceira>
{
    Task<IList<CategoriaFinanceira>> ListarCategoriasFinanceiraClinica(int idClinica);
}
