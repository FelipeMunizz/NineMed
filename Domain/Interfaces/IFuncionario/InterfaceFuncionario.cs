using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IFuncionario;

public interface InterfaceFuncionario : InterfaceGeneric<Funcionario>
{
    Task<IList<Funcionario>> ListarFuncionariosClinica(int idClinica);
    Task<Funcionario> ObterFuncionarioEmail(string email);
}
