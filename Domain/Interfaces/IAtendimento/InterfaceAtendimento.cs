using Domain.Interfaces.Generics;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Interfaces.IAtendimento;

public interface InterfaceAtendimento : InterfaceGeneric<Atendimento>
{
    Task<IList<Atendimento>> ListaAtentedimentoPaciente(int idPaciente);
    Task<RetornoGenerico<object>> GraficoAtendimentosMensal(int idClinica);
    Task<Atendimento> ObterAtendimentoAgendamento(int idAgendamento);
    Task<RetornoGenerico<object>> EvolucaoProntuarioByIdPaciente(int idPaciente);
}
