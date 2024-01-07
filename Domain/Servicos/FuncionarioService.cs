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

    public async Task AtualizarFuncionario(Funcionario obj)
    {
        await _repository.Update(obj);
    }

    public async Task DeletarFuncionario(int idFuncionaro)
    {
        Funcionario funcionario = await _repository.GetEntityById(idFuncionaro);
        if (funcionario != null)
        {
            await _repository.Delete(funcionario);
        }
    }
}
