using Domain.Interfaces.ISenhaToten;
using Domain.InterfacesServices;
using Entities.Models;

namespace Domain.Servicos;

public class SenhaTotenService : InterfaceSenhaTotenService
{
    private readonly InterfaceSenhaToten _repository;

    public SenhaTotenService(InterfaceSenhaToten repository)
    {
        _repository = repository;
    }

    public Task AdicionarSenhaToten(SenhaToten obj)
    {
        throw new NotImplementedException();
    }

    public Task AtualizarSenhaToten(SenhaToten obj)
    {
        throw new NotImplementedException();
    }

    public Task DeletarSenhasTotenDiarias(DateTime diaAtual)
    {
        throw new NotImplementedException();
    }
}
