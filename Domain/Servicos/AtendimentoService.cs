using Domain.Interfaces.IAtendimento;
using Domain.InterfacesServices.IAtendimentoService;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class AtendimentoService : InterfaceAtendimentoService
{
    private readonly InterfaceAtendimento _repository;

    public AtendimentoService(InterfaceAtendimento repository)
    {
        _repository = repository;
    }

    public async Task<RetornoGenerico<Atendimento>> AdicionarAtendimento(Atendimento atendimento)
    {
        atendimento = await _repository.Add(atendimento);
        if(atendimento.Id > 0)
        {
            return new RetornoGenerico<Atendimento>
            {
                Success = true,
                Message = "Atendimento cadastrado com sucesso"
            };
        }

        return new RetornoGenerico<Atendimento>
        {
            Success = false,
            Message = "Não foi possivel adicionar o atendimento"
        };
    }

    public async Task AtualizarAtendimento(Atendimento atendimento)
    {
        await _repository.Update(atendimento);
    }

    public async Task DeletarAtendimento(int idAtendimento)
    {
        Atendimento atendimento = await _repository.GetEntityById(idAtendimento);
        await _repository.Delete(atendimento);
    }
}
