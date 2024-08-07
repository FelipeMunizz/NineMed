﻿using Domain.Interfaces.IAtendimento;
using Domain.InterfacesServices.IAtendimentoService;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class AtendimentoService : InterfaceAtendimentoService
{
    private readonly InterfaceAtendimento _repository;
    private readonly InterfaceExameAtendimento _exameRepository;
    private readonly InterfacePrescricaoAtendimento _prescricaoRepository;
    private readonly InterfaceAtestadoAtendimento _atestadoRepository;
    private readonly InterfaceAnexosAtendimento _anexosRepository;

    public AtendimentoService(InterfaceAtendimento repository,
        InterfaceExameAtendimento exameRepository,
        InterfacePrescricaoAtendimento prescricaoRepository,
        InterfaceAtestadoAtendimento atestadoRepository,
        InterfaceAnexosAtendimento anexosRepository)
    {
        _repository = repository;
        _exameRepository = exameRepository;
        _prescricaoRepository = prescricaoRepository;
        _atestadoRepository = atestadoRepository;
        _anexosRepository = anexosRepository;
    }

    #region Atendimento
    public async Task<RetornoGenerico<Atendimento>> AdicionarAtendimento(Atendimento atendimento)
    {
        if (atendimento.IdAgendamento > 0)
        {
            Atendimento atendimentoCadastrado = await _repository.ObterAtendimentoAgendamento(atendimento.IdAgendamento);

            if (atendimentoCadastrado != null)
            {
                return new RetornoGenerico<Atendimento>
                {
                    Success = true,
                    Message = "Atendimento já cadastrado",
                    Result = atendimentoCadastrado
                };
            }
        }


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

    public async Task<RetornoGenerico<object>> GraficoAtendimentosMensal(int idClinica) => await _repository.GraficoAtendimentosMensal(idClinica);
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

    #region Prescrição
    public async Task<RetornoGenerico<PrescricaoAtendimento>> AdicionarPrescricaoAtendimento(PrescricaoAtendimento Prescricao)
    {
        Prescricao = await _prescricaoRepository.Add(Prescricao);

        if (Prescricao.Id > 0)
            return new RetornoGenerico<PrescricaoAtendimento>
            {
                Success = true,
                Message = "Prescrição adicionada com sucesso"
            };
        else
            return new RetornoGenerico<PrescricaoAtendimento> { Success = false, Message = "Não foi possivel adicionar a Prescricão." };
    }
    public async Task AtualizarPrescricaoAtendimento(PrescricaoAtendimento Prescricao)
    {
        await _prescricaoRepository.Update(Prescricao);
    }
    public async Task DeletarPrescricaoAtendimento(int idPrescricao)
    {
        PrescricaoAtendimento Prescricao = await ObterPrescricaoAtendimento(idPrescricao);

        if (Prescricao != null)
            await _prescricaoRepository.Delete(Prescricao);
    }
    public async Task<PrescricaoAtendimento> ObterPrescricaoAtendimento(int idPrescricao) => await _prescricaoRepository.GetEntityById(idPrescricao);
    public async Task<IList<PrescricaoAtendimento>> ListarPrescricaosAtendimento(int idAtendimento) => await _prescricaoRepository.ListaPrescricaoAtendimento(idAtendimento);
    #endregion

    #region Atestado
    public async Task<RetornoGenerico<AtestadoAtendimento>> AdicionarAtestadoAtendimento(AtestadoAtendimento Atestado)
    {
        Atestado = await _atestadoRepository.Add(Atestado);

        if (Atestado.Id > 0)
            return new RetornoGenerico<AtestadoAtendimento>
            {
                Success = true,
                Message = "Prescrição adicionada com sucesso"
            };
        else
            return new RetornoGenerico<AtestadoAtendimento> { Success = false, Message = "Não foi possivel adicionar a Prescricão." };
    }
    public async Task AtualizarAtestadoAtendimento(AtestadoAtendimento Atestado)
    {
        await _atestadoRepository.Update(Atestado);
    }
    public async Task DeletarAtestadoAtendimento(int idAtestado)
    {
        AtestadoAtendimento Atestado = await ObterAtestadoAtendimento(idAtestado);

        if (Atestado != null)
            await _atestadoRepository.Delete(Atestado);
    }
    public async Task<AtestadoAtendimento> ObterAtestadoAtendimento(int idAtestado) => await _atestadoRepository.GetEntityById(idAtestado);
    public async Task<IList<AtestadoAtendimento>> ListarAtestadosAtendimento(int idAtendimento) => await _atestadoRepository.ListaAtestadoAtendimento(idAtendimento);
    #endregion

    #region Anexos
    public async Task<RetornoGenerico<AnexosAtendimento>> AdicionarAnexosAtendimento(AnexosAtendimento Anexos)
    {
        Anexos = await _anexosRepository.Add(Anexos);

        if (Anexos.Id > 0)
            return new RetornoGenerico<AnexosAtendimento>
            {
                Success = true,
                Message = "Prescrição adicionada com sucesso"
            };
        else
            return new RetornoGenerico<AnexosAtendimento> { Success = false, Message = "Não foi possivel adicionar a Prescricão." };
    }
    public async Task AtualizarAnexosAtendimento(AnexosAtendimento Anexos)
    {
        await _anexosRepository.Update(Anexos);
    }
    public async Task DeletarAnexosAtendimento(int idAnexos)
    {
        AnexosAtendimento Anexos = await ObterAnexosAtendimento(idAnexos);

        if (Anexos != null)
            await _anexosRepository.Delete(Anexos);
    }
    public async Task<AnexosAtendimento> ObterAnexosAtendimento(int idAnexos) => await _anexosRepository.GetEntityById(idAnexos);
    public async Task<IList<AnexosAtendimento>> ListarAnexossAtendimento(int idAtendimento) => await _anexosRepository.ListaAnexosAtendimento(idAtendimento);
    #endregion
}
