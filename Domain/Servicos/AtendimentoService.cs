using Domain.Interfaces.IAtendimento;
using Domain.InterfacesServices.IAtendimentoService;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class AtendimentoService : InterfaceAtendimentoService
{
    private readonly InterfaceAtendimento _repository;
    private readonly InterfaceExameAtendimento _exameRepository;

    public AtendimentoService(InterfaceAtendimento repository,
        InterfaceExameAtendimento exameRepository)
    {
        _repository = repository;
        _exameRepository = exameRepository;
    }

    #region Atendimento
    public async Task<RetornoGenerico<Atendimento>> AdicionarAtendimento(Atendimento atendimento)
    {
        atendimento = await _repository.Add(atendimento);
        if (atendimento.Id > 0)
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
    #endregion

    #region Exames
    public async Task<RetornoGenerico<ExameAtendimento>> AdicionarExameAtendimento(ExameAtendimento exame)
    {
        exame = await _exameRepository.Add(exame);

        if (exame.Id > 0)
            return new RetornoGenerico<ExameAtendimento>
            {
                Success = true,
                Message = "Exame adicionado com sucesso"
            };
        else
            return new RetornoGenerico<ExameAtendimento> { Success = false, Message = "Não foi possivel adicionar o exame." };
    }
    public async Task AtualizarExameAtendimento(ExameAtendimento exame)
    {
        await _exameRepository.Update(exame);
    }
    public async Task DeletarExameAtendimento(int idExame)
    {
        ExameAtendimento exame = await ObterExameAtendimento(idExame);

        if (exame != null)
            await _exameRepository.Delete(exame);
    }
    public async Task<ExameAtendimento> ObterExameAtendimento(int idExame) => await _exameRepository.GetEntityById(idExame);
    public async Task<IList<ExameAtendimento>> ListarExamesAtendimento(int idAtendimento) => await _exameRepository.ListaAxamesAtendimento(idAtendimento);
    #endregion
}
