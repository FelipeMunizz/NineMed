using Domain.Interfaces.IAgendamento;
using Domain.Interfaces.IConfiguracaoClinica;
using Domain.Interfaces.IProcedimento;
using Domain.InterfacesServices.IAgendamentoService;
using Domain.InterfacesServices.IConvenioService;
using Domain.InterfacesServices.IFuncionarioService;
using Entities.Enums;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class AgendamentoService : InterfaceAgendamentoService
{
    private readonly InterfaceAgendamento _repositoryAgendamento;
    private readonly InterfaceConfiguracaoClinica _repositoryConfigClinica;
    private readonly InterfaceProcedimento _repositorioProcedimento;
    private readonly InterfaceFuncionarioService _serviceFuncionario;
    private readonly InterfaceConvenioService _serviceConvenio;

    public AgendamentoService(InterfaceAgendamento repositoryAgendamento, 
        InterfaceConfiguracaoClinica repositoryConfigClinica, 
        InterfaceProcedimento repositorioProcedimento, 
        InterfaceFuncionarioService serviceFuncionario, 
        InterfaceConvenioService serviceConvenio)
    {
        _repositoryAgendamento = repositoryAgendamento;
        _repositoryConfigClinica = repositoryConfigClinica;
        _repositorioProcedimento = repositorioProcedimento;
        _serviceFuncionario = serviceFuncionario;
        _serviceConvenio = serviceConvenio;
    }

    public async Task<IList<Agendamento>> ListaAgendamentosPaciente(int idPaciente) => await _repositoryAgendamento.ListaAgendamentosCliente(idPaciente);
    public async Task<IList<Agendamento>> ListaAgendamentosClinica(int idClinica) => await _repositoryAgendamento.ListaAgendamentosClinica(idClinica);
    public async Task<IList<Agendamento>> ListaAgendamentosDia(int idClinica, DateTime dia) => await _repositoryAgendamento.ListaAgendamentosDia(idClinica, dia);
    public async Task<IList<Agendamento>> ListaAgendamentosFuncionario(int idFuncionario) => await _repositoryAgendamento.ListaAgendamentosFuncionario(idFuncionario);
    public async Task<RetornoGenerico<object>> GraficoAgendamento(int idClincia) => await _repositoryAgendamento.GraficoAgendamento(idClincia);
    public async Task<RetornoGenerico<Agendamento>> AdicionarAgendamento(Agendamento agendamento)
    {
        ConfiguracaoClinica configClinica = await _repositoryConfigClinica.ObterConfiguracaoClinica(agendamento.IdClinica);

        if (!ValidaHorarioClinica(agendamento.HoraAgendamento, configClinica))
            return new RetornoGenerico<Agendamento>
            {
                Success = false,
                Message = "Horario de agendamento não condiz com abertura e fechamento da clinica"
            };

        Funcionario funcionario = await _serviceFuncionario.ObterFuncionario(agendamento.IdFuncionario);

        int tempoTotalAgendamento = 0;

        for (int i = 0; agendamento.IdsProcedimento.Length > i; i++)
        {
            Procedimento procedimento = await _repositorioProcedimento.GetEntityById(agendamento.IdsProcedimento[i]);
            if (procedimento != null)
                tempoTotalAgendamento += procedimento.Duracao;
        }

        TimeOnly tempoAgendado = TimeOnly.FromDateTime(DateTime.MinValue.AddMinutes(tempoTotalAgendamento));

        agendamento.DataAgendamento = new DateTime(
                agendamento.DataAgendamento.Year,
                agendamento.DataAgendamento.Month,
                agendamento.DataAgendamento.Day,
                agendamento.HoraAgendamento.Hour,
                agendamento.HoraAgendamento.Minute,
                agendamento.HoraAgendamento.Second
            );

        var horario = await _serviceFuncionario.HorarioFuncionarioIntervalo(agendamento.IdFuncionario, agendamento.DataAgendamento, tempoAgendado);

        if (horario > 0)
            return new RetornoGenerico<Agendamento>
            {
                Success = false,
                Message = "Profissional da Saúde ja possui horario agendado neste periodo."
            };

        HorarioFuncionario horarioFuncionario = new HorarioFuncionario
        {
            IdFuncionario = agendamento.IdFuncionario,
            DataHorario = agendamento.DataAgendamento,
            TempoAgendado = tempoAgendado
        };

        if (funcionario.ProfissionalSaude 
            && await _serviceConvenio.ProfissionalAtendeConvenio(funcionario.Id, agendamento.IdConvenio))
        {
            await _serviceFuncionario.AdicionarHorarioFuncionario(horarioFuncionario);
            agendamento = await _repositoryAgendamento.Add(agendamento);
        }
        else
            return new RetornoGenerico<Agendamento>
            {
                Success = false,
                Message = "Apenas profissionais da saúde podem ter horários agendados. Ou o profissional não atende este convenio."
            };

        return new RetornoGenerico<Agendamento>
        {
            Success = true,
            Message = "Agendamento salvo com sucesso",
            Result = agendamento
        };
    }

    public async Task AtualizarAgendamento(Agendamento agendamento)
    {
        await _repositoryAgendamento.Update(agendamento);
    }

    public async Task<RetornoGenerico<Agendamento>> ConfirmarAgendamento(int idAgendamento)
    {
        Agendamento agendamento = await ObterAgendamento(idAgendamento);
        if (agendamento != null && !agendamento.SituacaoAgendamento.Equals(SituacaoAgendamento.Confirmado))
        {
            agendamento.SituacaoAgendamento = SituacaoAgendamento.Confirmado;
            await AtualizarAgendamento(agendamento);

            return new RetornoGenerico<Agendamento>
            {
                Success = true,
                Message = "Agendamento Confirmado com Sucesso",
                Result = agendamento
            };
        }

        return new RetornoGenerico<Agendamento>
        {
            Success = false,
            Message = "Não foi possivel confirmar o agendamento"
        };
    }

    public async Task<Agendamento> ObterAgendamento(int idAgendamento)
    {
       var teste = await _repositoryAgendamento.GetEntityById(idAgendamento);
        return teste;
    }

    public async Task<RetornoGenerico<object>> AgendamentoPacienteDiario(int idClinica) => 
        await _repositoryAgendamento.AgendamentoPacienteDiario(idClinica);

    public async Task<RetornoGenerico<object>> AgendamentosAtendimento(int idFuncionario) => 
        await _repositoryAgendamento.AgendamentosAtendimento(idFuncionario);

    private bool ValidaHorarioClinica(TimeOnly horarioAgendamento, ConfiguracaoClinica configClinica)
    {
        if (horarioAgendamento < configClinica.HorarioAbertura || horarioAgendamento >= configClinica.HorarioFechamento)
        {
            return false;
        }

        return true;
    }
}
