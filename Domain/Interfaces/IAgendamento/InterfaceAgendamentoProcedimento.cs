using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IAgendamento;

public interface InterfaceAgendamentoProcedimento : InterfaceGeneric<AgendamentoProcedimento>
{
    Task<IList<AgendamentoProcedimento>> ListaAgendamentosProcedimento(int idAgendamento);
}
