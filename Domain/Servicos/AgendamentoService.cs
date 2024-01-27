using Domain.Interfaces.IAgendamento;
using Domain.Interfaces.IConfiguracaoClinica;
using Domain.Interfaces.IProcedimento;
using Domain.InterfacesServices.IAgendamentoService;
using Domain.InterfacesServices.IFuncionarioService;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class AgendamentoService : InterfaceAgendamentoService
{
    private readonly InterfaceAgendamento _repositoryAgendamento;
    private readonly InterfaceAgendamentoProcedimento _repositoryAgendamentoProcedimento;
    private readonly InterfaceConfiguracaoClinica _repositoryConfigClinica;
    private readonly InterfaceProcedimento _repositorioProcedimento;
    private readonly InterfaceFuncionarioService _serviceFuncionario;

    public AgendamentoService(InterfaceAgendamento repositoryAgendamento,
        InterfaceAgendamentoProcedimento repositoryAgendamentoProcedimento,
        InterfaceConfiguracaoClinica repositoryConfigClinica,
        InterfaceProcedimento repositorioProcedimento,
        InterfaceFuncionarioService serviceFuncionario)
    {
        _repositoryAgendamento = repositoryAgendamento;
        _repositoryAgendamentoProcedimento = repositoryAgendamentoProcedimento;
        _repositoryConfigClinica = repositoryConfigClinica;
        _repositorioProcedimento = repositorioProcedimento;
        _serviceFuncionario = serviceFuncionario;
    }
    public async Task<IList<Agendamento>> ListaAgendamentosPaciente(int idPaciente) => await _repositoryAgendamento.ListaAgendamentosCliente(idPaciente);
    public async Task<IList<Agendamento>> ListaAgendamentosClinica(int idClinica) => await _repositoryAgendamento.ListaAgendamentosClinica(idClinica);
    public async Task<IList<Agendamento>> ListaAgendamentosDia(int idClinica, DateTime dia) => await _repositoryAgendamento.ListaAgendamentosDia(idClinica, dia);
    public async Task<IList<Agendamento>> ListaAgendamentosFuncionario(int idFuncionario) => await _repositoryAgendamento.ListaAgendamentosFuncionario(idFuncionario);

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

    public async Task AtualizarAgendamento(Agendamento agendamento)
    {
        await _repositoryAgendamento.Update(agendamento);
    }

    public async Task AtualizarAgendamentoProcedimento(AgendamentoProcedimento agendamentoProcedimento)
    {
        await _repositoryAgendamentoProcedimento.Update(agendamentoProcedimento);
    }

    public async Task<object> DeletarAgendamentoProcedimento(int idAgendamentoProcedimento)
    {
        AgendamentoProcedimento procedimento = await _repositoryAgendamentoProcedimento.GetEntityById(idAgendamentoProcedimento);
        if (procedimento != null)
        {
            await _repositoryAgendamentoProcedimento.Delete(procedimento);
            return new RetornoGenerico<object>
            {
                Success = true,
                Message = "Procedimento deletado com sucesso do agendamento"
            };
        }
        else
            return new RetornoGenerico<object>
            {
                Success = false,
                Message = "Procedimento não localizado no agendamento"
            };
    }

    public async Task<IList<AgendamentoProcedimento>> ListaAgendamentoProcedimento(int idProcedimento) =>
        await _repositoryAgendamentoProcedimento.ListaAgendamentosProcedimento(idProcedimento);

    public async Task<AgendamentoProcedimento> ObterAgendamentoProcedimento(int idAgendamentoProcedimento) =>
        await _repositoryAgendamentoProcedimento.GetEntityById(idAgendamentoProcedimento);
    public async Task<Agendamento> ObterAgendamento(int idAgendamento) =>
        await _repositoryAgendamento.GetEntityById(idAgendamento);

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
