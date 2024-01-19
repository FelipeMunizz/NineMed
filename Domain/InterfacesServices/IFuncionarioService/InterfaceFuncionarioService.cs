using Entities.Models;

namespace Domain.InterfacesServices.IFuncionarioService;

public interface InterfaceFuncionarioService
{
    Task AdicionarFuncionario(Funcionario obj);
    Task AtualizarFuncionario(Funcionario obj);
    Task DeletarFuncionario(int idFuncionaro);
    Task<Funcionario> ObterFuncionario(int idFuncionario);

    Task AdicionarHorarioFuncionario(HorarioFuncionario horario);
    Task AtualizaHorarioFuncionario(HorarioFuncionario horario);
    Task DeletaHorarioFuncionario(int idHorario);
    Task<IList<HorarioFuncionario>> ListaHorariosFuncionario(int idFuncionario);
    Task<int> HorarioFuncionarioIntervalo(int idFuncionario, DateTime dtAgendamento, TimeOnly tempoAgendado);
    Task<IList<HorarioFuncionario>> ListaHorariosFuncionarioPeriodo(int idFuncionario, DateTime dtInicio, DateTime dtFim);
}
