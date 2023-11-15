using Domain.Interfaces.IFuncionario;
using Domain.InterfacesServices.IFuncionarioService;
using Entities.Models;

namespace Domain.Servicos;

public class FuncionarioService : InterfaceFuncionarioService
{
    private readonly InterfaceFuncionario _repository;

    public FuncionarioService(InterfaceFuncionario repository)
    {
        _repository = repository;
    }

    public async Task AdicionarFuncionario(Funcionario obj)
    {        
        await _repository.Add(obj);
    }
}
