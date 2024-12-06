using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.IAgendamentoService;

public interface InterfaceAgendamentoService
{
    Task<RetornoGenerico<Agendamento>> AdicionarAgendamento(Agendamento agendamento);
    Task AtualizarAgendamento(Agendamento agendamento);
    Task<RetornoGenerico<Agendamento>> ConfirmarAgendamento(int idAgendamento);
    Task<IList<Agendamento>> ListaAgendamentosPaciente(int idPaciente);
    Task<IList<Agendamento>> ListaAgendamentosClinica(int idClinica);
    Task<IList<Agendamento>> ListaAgendamentosDia(int idClinica, DateTime dia);
    Task<IList<Agendamento>> ListaAgendamentosFuncionario(int idFuncionario);
    Task<Agendamento> ObterAgendamento(int idAgendamento);
    Task<RetornoGenerico<object>> GraficoAgendamento(int idClinica);
    Task<RetornoGenerico<object>> AgendamentoPacienteDiario(int idClinica);
    Task<RetornoGenerico<object>> AgendamentosAtendimento(int idFuncionario);
}
