using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IAgendamento;

public interface InterfaceAgendamentoPagamento : InterfaceGeneric<AgendamentoPagamento>
{
    Task<IList<AgendamentoPagamento>> ListaAgendamentosPagamento(int idAgendamento);
}
