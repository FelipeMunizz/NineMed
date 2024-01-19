using Domain.Interfaces.IAgendamento;
using Domain.Interfaces.IConfiguracaoClinica;
using Domain.Interfaces.IFuncionario;
using Domain.Interfaces.IProcedimento;
using Domain.InterfacesServices.IAgendamentoService;
using Domain.InterfacesServices.IFuncionarioService;
using Entities.Enums;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class AgendamentoService : InterfaceAgendamentoService
{
    private readonly InterfaceAgendamento _repositoryAgendamento;
    private readonly InterfaceAgendamentoProcedimento _repositoryAgendamentoProcedimento;
    private readonly InterfaceAgendamentoPagamento _repositoryAgendamentoPagamento;
    private readonly InterfaceConfiguracaoClinica _repositoryConfigClinica;
    private readonly InterfaceProcedimento _repositorioProcedimento;
    private readonly InterfaceFuncionarioService _serviceFuncionario;

    public AgendamentoService(InterfaceAgendamento repositoryAgendamento,
        InterfaceAgendamentoProcedimento repositoryAgendamentoProcedimento,
        InterfaceAgendamentoPagamento repositoryAgendamentoPagamento,
        InterfaceConfiguracaoClinica repositoryConfigClinica,
        InterfaceProcedimento repositorioProcedimento,
        InterfaceFuncionarioService serviceFuncionario)
    {
        _repositoryAgendamento = repositoryAgendamento;
        _repositoryAgendamentoProcedimento = repositoryAgendamentoProcedimento;
        _repositoryAgendamentoPagamento = repositoryAgendamentoPagamento;
        _repositoryConfigClinica = repositoryConfigClinica;
        _repositorioProcedimento = repositorioProcedimento;
        _serviceFuncionario = serviceFuncionario;
    }

    public async Task<object> AdicionarAgendamento(Agendamento agendamento,
        IList<AgendamentoProcedimento> agendamentoProcedimentos)
    {
        ConfiguracaoClinica configClinica = await _repositoryConfigClinica.ObterConfiguracaoClinica(agendamento.IdClinica);

        if (!ValidaHorarioClinica(agendamento.DataAgendamento, configClinica))
            return new RetornoGenerico<string>
            {
                Success = false,
                Message = "Horario de agendamento não condiz com abertura e fechamento da clinica",
                Result = string.Empty
            };

        Funcionario funcionario = await _serviceFuncionario.ObterFuncionario(agendamento.IdFuncionario);

        if (funcionario.ProfissionalSaude)
            agendamento = await _repositoryAgendamento.Add(agendamento);
        else
            return new RetornoGenerico<object>
            {
                Success = false,
                Message = "Apenas profissionais da saúde podem ter horários agendados."
            };

        if (agendamento.Id > 0)
        {
            int tempoTotalAgendamento = 0;

            foreach (AgendamentoProcedimento procedimentoAgendados in agendamentoProcedimentos)
            {
                if (procedimentoAgendados != null)
                {
                    Procedimento procedimento = await _repositorioProcedimento.GetEntityById(procedimentoAgendados.IdProcedimento);
                    if (procedimento != null)
                        tempoTotalAgendamento += procedimento.Duracao;

                    procedimentoAgendados.IdAgendamento = agendamento.Id;
                    await AdicionarAgendamentoProcedimento(procedimentoAgendados);
                }
            }

            TimeOnly tempoAgendado = TimeOnly.FromDateTime(DateTime.MinValue.AddMinutes(tempoTotalAgendamento));

            HorarioFuncionario horarioFuncionario = new HorarioFuncionario
            {
                IdFuncionario = agendamento.IdFuncionario,
                DataHorario = agendamento.DataAgendamento,
                TempoAgendado = tempoAgendado
            };

            await _serviceFuncionario.AdicionarHorarioFuncionario(horarioFuncionario);
        }
        else
            return new RetornoGenerico<object>
            {
                Success = false,
                Message = "Não foi possivel salvar o Agendamento"
            };

        return new RetornoGenerico<Agendamento>
        {
            Success = true,
            Message = "Agendamento salvo com sucesso",
            Result = agendamento
        };
    }

    public async Task AdicionarAgendamentoPagamento(AgendamentoPagamento agendamentoPagamento)
    {
        await _repositoryAgendamentoPagamento.Add(agendamentoPagamento);
    }

    public async Task AdicionarAgendamentoProcedimento(AgendamentoProcedimento agendamentoProcedimento)
    {
        Procedimento procedimento = await _repositorioProcedimento.GetEntityById(agendamentoProcedimento.IdProcedimento);

        if (procedimento != null)
        {
            agendamentoProcedimento.ValorTotal =
                agendamentoProcedimento.Quantidade * procedimento.Preco;

            await _repositoryAgendamentoProcedimento.Add(agendamentoProcedimento);
        }
    }

    public Task<object> AtualizarAgendamento(Agendamento agendamento)
    {
        throw new NotImplementedException();
    }

    public Task AtualizarAgendamentoPagamento(AgendamentoPagamento agendamentoPagamento)
    {
        throw new NotImplementedException();
    }

    public Task AtualizarAgendamentoProcedimento(AgendamentoProcedimento agendamentoProcedimento)
    {
        throw new NotImplementedException();
    }

    public Task DeletarAgendamentoPagamento(int idAgendamentoPagamento)
    {
        throw new NotImplementedException();
    }

    public Task DeletarAgendamentoProcedimento(int idAgendamentoProcedimento)
    {
        throw new NotImplementedException();
    }

    public Task<IList<AgendamentoPagamento>> ListaAgendamentoPagamento(int idPagamento)
    {
        throw new NotImplementedException();
    }

    public Task<IList<AgendamentoProcedimento>> ListaAgendamentoProcedimento(int idProcedimento)
    {
        throw new NotImplementedException();
    }

    public Task<AgendamentoPagamento> ObterAgendamentoPagamento(int idAgendamentoPagamento)
    {
        throw new NotImplementedException();
    }

    public Task<AgendamentoProcedimento> ObterAgendamentoProcedimento(int idAgendamentoProcedimento)
    {
        throw new NotImplementedException();
    }

    private bool ValidaHorarioClinica(DateTime horarioAgendamento, ConfiguracaoClinica configClinica)
    {
        TimeOnly horario = new TimeOnly(horarioAgendamento.Hour, horarioAgendamento.Minute);

        if (horario < configClinica.HorarioAbertura || horario >= configClinica.HorarioFechamento)
        {
            return false;
        }

        return true;
    }
}
