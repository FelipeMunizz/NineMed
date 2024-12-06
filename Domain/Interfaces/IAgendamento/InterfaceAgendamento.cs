using Domain.Interfaces.Generics;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Interfaces.IAgendamento;

public interface InterfaceAgendamento : InterfaceGeneric<Agendamento>
{
    Task<IList<Agendamento>> ListaAgendamentosClinica(int idPaciente);
    Task<IList<Agendamento>> ListaAgendamentosFuncionario(int idFuncionario);
    Task<IList<Agendamento>> ListaAgendamentosCliente(int idCliente);
    Task<IList<Agendamento>> ListaAgendamentosDia(int idClinica, DateTime dia);
    Task<RetornoGenerico<object>> GraficoAgendamento(int idClinica);
    Task<RetornoGenerico<object>> AgendamentoPacienteDiario(int idClinica);
    Task<RetornoGenerico<object>> AgendamentosAtendimento(int idFuncionario);
}
