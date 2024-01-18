using Domain.Interfaces.IAgendamento;
using Domain.Interfaces.IConfiguracaoClinica;
using Domain.Interfaces.IFuncionario;
using Domain.Interfaces.IProcedimento;
using Domain.InterfacesServices.IAgendamentoService;
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
    private readonly InterfaceHorarioFuncionario _repositorioHorarioFuncionario;

    public AgendamentoService(InterfaceAgendamento repositoryAgendamento,
        InterfaceAgendamentoProcedimento repositoryAgendamentoProcedimento,
        InterfaceAgendamentoPagamento repositoryAgendamentoPagamento,
        InterfaceConfiguracaoClinica repositoryConfigClinica,
        InterfaceProcedimento repositorioProcedimento,
        InterfaceHorarioFuncionario repositorioHorarioFuncionario)
    {
        _repositoryAgendamento = repositoryAgendamento;
        _repositoryAgendamentoProcedimento = repositoryAgendamentoProcedimento;
        _repositoryAgendamentoPagamento = repositoryAgendamentoPagamento;
        _repositoryConfigClinica = repositoryConfigClinica;
        _repositorioProcedimento = repositorioProcedimento;
        _repositorioHorarioFuncionario = repositorioHorarioFuncionario;
    }

    public async Task<object> AdicionarAgendamento(Agendamento agendamento, 
        IList<AgendamentoProcedimento> agendamentoProcedimentos, 
        IList<AgendamentoPagamento> agendamentoPagamentos)
    {
        ConfiguracaoClinica configClinica = await _repositoryConfigClinica.ObterConfiguracaoClinica(agendamento.IdClinica);

        if (!ValidaHorarioClinica(agendamento.DataAgendamento, configClinica))
            return new RetornoGenerico<string>
            {
                Success = false,
                Message = "Horario de agendamento não condiz com abertura e fechamento da clinica",
                Result = string.Empty
            };

        agendamento = await _repositoryAgendamento.Add(agendamento);

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
                    _repositoryAgendamentoProcedimento.Add(procedimentoAgendados);
                }
            }

            foreach (AgendamentoPagamento pagamento in agendamentoPagamentos)
            {
                pagamento.IdAgendamento = agendamento.Id;
                _repositoryAgendamentoPagamento.Add(pagamento);
            }

            TimeOnly tempoAgendado = TimeOnly.FromDateTime(DateTime.MinValue.AddMinutes(tempoTotalAgendamento));

            HorarioFuncionario horarioFuncionario = new HorarioFuncionario
            {
                IdFuncionario = agendamento.IdFuncionario,
                DataHorario = agendamento.DataAgendamento,
                TempoAgendado = tempoAgendado
            };

            await _repositorioHorarioFuncionario.Add(horarioFuncionario);
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

    public Task<object> AdicionarAgendamento(Agendamento agendamento, AgendamentoProcedimento procedimento)
    {
        throw new NotImplementedException();
    }

    public Task AdicionarAgendamentoPagamento(AgendamentoPagamento agendamentoPagamento)
    {
        throw new NotImplementedException();
    }

    public Task AdicionarAgendamentoProcedimento(AgendamentoProcedimento agendamentoProcedimento)
    {
        throw new NotImplementedException();
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
