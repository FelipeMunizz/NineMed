using Entities.Models;

namespace Domain.InterfacesServices.IFuncionarioService;

public interface InterfaceFuncionarioService
{
    Task AdicionarFuncionario(Funcionario obj);
    Task AtualizarFuncionario(Funcionario obj);
    Task DeletarFuncionario(int idFuncionaro);
}
