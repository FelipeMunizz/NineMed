using Entities.Models;

namespace Domain.InterfacesServices.IAgendamentoService;

public interface InterfaceAgendamentoService
{
    Task<object> AdicionarAgendamento(Agendamento agendamento,
        IList<AgendamentoProcedimento> agendamentoProcedimentos);
    Task AtualizarAgendamento(Agendamento agendamento);
    Task<IList<Agendamento>> ListaAgendamentosPaciente(int idPaciente);
    Task<IList<Agendamento>> ListaAgendamentosClinica(int idClinica);
    Task<IList<Agendamento>> ListaAgendamentosDia(int idClinica, DateTime dia);
    Task<IList<Agendamento>> ListaAgendamentosFuncionario(int idFuncionario);
    Task<Agendamento> ObterAgendamento(int idAgendamento);

    #region Agendamento Procedimento
    Task<IList<AgendamentoProcedimento>> ListaAgendamentoProcedimento(int idProcedimento);
    Task<AgendamentoProcedimento> ObterAgendamentoProcedimento(int idAgendamentoProcedimento);
    Task AdicionarAgendamentoProcedimento(AgendamentoProcedimento agendamentoProcedimento);
    Task AtualizarAgendamentoProcedimento(AgendamentoProcedimento agendamentoProcedimento);
    Task<object> DeletarAgendamentoProcedimento(int idAgendamentoProcedimento);
    #endregion

    #region Agendamento Pagamento
    Task<IList<AgendamentoPagamento>> ListaAgendamentoPagamento(int idPagamento);
    Task<AgendamentoPagamento> ObterAgendamentoPagamento(int idAgendamentoPagamento);
    Task AdicionarAgendamentoPagamento(AgendamentoPagamento agendamentoPagamento);
    Task AtualizarAgendamentoPagamento(AgendamentoPagamento agendamentoPagamento);
    #endregion
}
