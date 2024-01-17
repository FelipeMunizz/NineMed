using Entities.Models;

namespace Domain.InterfacesServices.IAgendamentoService;

public interface InterfaceAgendamentoService
{
    Task<object> AdicionarAgendamento(Agendamento agendamento, AgendamentoProcedimento procedimento);
    Task<object> AtualizarAgendamento(Agendamento agendamento);

    #region Agendamento Procedimento
    Task<IList<AgendamentoProcedimento>> ListaAgendamentoProcedimento(int idProcedimento);
    Task<AgendamentoProcedimento> ObterAgendamentoProcedimento(int idAgendamentoProcedimento);
    Task AdicionarAgendamentoProcedimento(AgendamentoProcedimento agendamentoProcedimento);
    Task AtualizarAgendamentoProcedimento(AgendamentoProcedimento agendamentoProcedimento);
    Task DeletarAgendamentoProcedimento(int idAgendamentoProcedimento);
    #endregion

    #region Agendamento Pagamento
    Task<IList<AgendamentoPagamento>> ListaAgendamentoPagamento(int idPagamento);
    Task<AgendamentoPagamento> ObterAgendamentoPagamento(int idAgendamentoPagamento);
    Task AdicionarAgendamentoPagamento(AgendamentoPagamento agendamentoPagamento);
    Task AtualizarAgendamentoPagamento(AgendamentoPagamento agendamentoPagamento);
    Task DeletarAgendamentoPagamento(int idAgendamentoPagamento);
    #endregion
}
