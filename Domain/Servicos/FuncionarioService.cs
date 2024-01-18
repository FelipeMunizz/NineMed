using Domain.Interfaces.IFuncionario;
using Domain.InterfacesServices.IFuncionarioService;
using Entities.Models;

namespace Domain.Servicos;

public class FuncionarioService : InterfaceFuncionarioService
{
    private readonly InterfaceFuncionario _repository;
    private readonly InterfaceHorarioFuncionario _repositoryHorario;

    public FuncionarioService(InterfaceFuncionario repository, InterfaceHorarioFuncionario repositoryHorario)
    {
        _repository = repository;
        _repositoryHorario = repositoryHorario;
    }

    public async Task AdicionarFuncionario(Funcionario obj)
    {        
        await _repository.Add(obj);
    }

    public async Task AtualizarFuncionario(Funcionario obj)
    {
        await _repository.Update(obj);
    }

    public async Task DeletarFuncionario(int idFuncionaro)
    {
        Funcionario funcionario = await _repository.GetEntityById(idFuncionaro);
        if (funcionario != null)
        {
            await _repository.Delete(funcionario);
        }
    }


    public async Task AdicionarHorarioFuncionario(HorarioFuncionario horario)
    {
        await _repositoryHorario.Add(horario);
    }

    public async Task AtualizaHorarioFuncionario(HorarioFuncionario horario)
    {
        await _repositoryHorario.Update(horario);
    }

    public async Task DeletaHorarioFuncionario(int idHorario)
    {
        HorarioFuncionario horario = await _repositoryHorario.GetEntityById(idHorario);

        if(horario != null)
            await _repositoryHorario.Delete(horario);
    }

    public async Task<int> HorarioFuncionarioIntervalo(int idFuncionario, DateTime dtAgendamento, TimeOnly tempoAgendado)
    {
        return await _repositoryHorario.HorarioFuncionarioIntervalo(idFuncionario, dtAgendamento, tempoAgendado);
    }

    public async Task<IList<HorarioFuncionario>> ListaHorariosFuncionario(int idFuncionario)
    {
        return await _repositoryHorario.ListaHorariosFuncionario(idFuncionario);
    }

    public async Task<IList<HorarioFuncionario>> ListaHorariosFuncionarioPeriodo(int idFuncionario, DateTime dtInicio, DateTime dtFim)
    {
        return await _repositoryHorario.ListaHorariosFuncionarioPeriodo(idFuncionario , dtInicio, dtFim);
    }
}
