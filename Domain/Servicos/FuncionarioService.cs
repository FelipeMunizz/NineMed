using Domain.Interfaces.IFuncionario;
using Domain.InterfacesServices.IFuncionarioService;
using Entities.Models;
using Entities.Retorno;
using Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace Domain.Servicos;

public class FuncionarioService : InterfaceFuncionarioService
{
    private readonly InterfaceFuncionario _repository;
    private readonly InterfaceHorarioFuncionario _repositoryHorario;
    private readonly UserManager<ApplicationUser> _userManager;

    public FuncionarioService(InterfaceFuncionario repository, 
        InterfaceHorarioFuncionario repositoryHorario, 
        UserManager<ApplicationUser> userManager)
    {
        _repository = repository;
        _repositoryHorario = repositoryHorario;
        _userManager = userManager;
    }

    public async Task<Funcionario> ObterFuncionario(int idFuncionario) => await _repository.GetEntityById(idFuncionario);
    public async Task<Funcionario> ObterFuncionarioEmail(string email) => await _repository.ObterFuncionarioEmail(email);

    public async Task<RetornoGenerico<Funcionario>> AdicionarFuncionario(Funcionario obj)
    {
        obj = await _repository.Add(obj);

        if (obj.Id > 0)
            return new RetornoGenerico<Funcionario>
            {
                Success = true,
                Message = "Funcionario adicionado com sucesso",
                Result = obj
            };
        else
            return new RetornoGenerico<Funcionario>
            {
                Success = false,
                Message = "Não foi possivel adicionar funcionario",
            };
    }

    public async Task AtualizarFuncionario(Funcionario obj)
    {
        await _repository.Update(obj);
    }

    public async Task<RetornoGenerico<bool>> AtualizarSenhaFuncionario(LoginUserDTO loginUserDTO)
    {
        var user = await _userManager.FindByEmailAsync(loginUserDTO.Email);

        if (user == null)
            return new RetornoGenerico<bool>
            {
                Success = false,
                Message = "Usuario não encontrado",
                Result = false
            };

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, token, loginUserDTO.Password);

        return new RetornoGenerico<bool>
        {
            Success = true,
            Message = "Senha atualizada com sucesso",
            Result = true
        };
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

        if (horario != null)
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
        return await _repositoryHorario.ListaHorariosFuncionarioPeriodo(idFuncionario, dtInicio, dtFim);
    }
}
