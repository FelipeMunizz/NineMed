using Entities.Models;

namespace Domain.InterfacesServices.IFuncionarioService;

public interface InterfaceFuncionarioService
{
    Task AdicionarFuncionario(Funcionario obj);
    Task AtualizarFuncionario(Funcionario obj);
    Task DeletarFuncionario(int idFuncionaro);

    Task AdicionarHorarioFuncionario(HorarioFuncionario horario);
    Task AtualizaHorarioFuncionario(HorarioFuncionario horario);
    Task DeletaHorarioFuncionario(int idHorario);
    Task<IList<HorarioFuncionario>> ListaHorariosFuncionario(int idFuncionario);
    Task<IList<HorarioFuncionario>> HorarioFuncionarioIntervalo(int idFuncionario, DateTime dtAgendamento, TimeOnly tempoAgendado);
    Task<IList<HorarioFuncionario>> ListaHorariosFuncionarioPeriodo(int idFuncionario, DateTime dtInicio, DateTime dtFim);
}
