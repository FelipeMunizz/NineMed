using Domain.Interfaces.IProcedimento;
using Domain.InterfacesServices.IProcedimentoService;
using Entities.Models;

namespace Domain.Servicos;

public class ProcedimentoService : InterfaceProcedimentoService
{
    private readonly InterfaceProcedimento _repository;

    public ProcedimentoService(InterfaceProcedimento repository)
    {
        _repository = repository;
    }

    public async Task AdicionarProcedimento(Procedimento procedimento)
    {
        await _repository.Add(procedimento);
    }

    public async Task EditarProcedimento(Procedimento procedimento)
    {
        await _repository.Update(procedimento);
    }

    public async Task ExcluirProcedimento(int idProcedimento)
    {
        Procedimento procedimento = await _repository.GetEntityById(idProcedimento);
        if (procedimento != null)
            await _repository.Delete(procedimento);
    }
}
