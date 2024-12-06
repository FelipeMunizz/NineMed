using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IFuncionario;

public interface InterfaceHorarioFuncionario : InterfaceGeneric<HorarioFuncionario>
{
    Task<IList<HorarioFuncionario>> ListaHorariosFuncionario(int idFuncionario);
    Task<IList<HorarioFuncionario>> ListaHorariosFuncionarioPeriodo(int idFuncionario, DateTime dtInicio, DateTime dtFim);
    Task<int> HorarioFuncionarioIntervalo(int idFuncionario, DateTime dtAgendamento, TimeOnly tempoAgendado);
}
