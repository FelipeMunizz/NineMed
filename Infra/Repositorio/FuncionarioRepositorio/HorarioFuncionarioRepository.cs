using Domain.Interfaces.IFuncionario;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Infra.Repositorio.FuncionarioRepositorio;

public class HorarioFuncionarioRepository : RepositorioGenerico<HorarioFuncionario>, InterfaceHorarioFuncionario
{
    private readonly DbContextOptions<AppDbContext> _context;

    public HorarioFuncionarioRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<HorarioFuncionario>> ListaHorariosFuncionario(int idFuncionario)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                    from hf in banco.HorarioFuncionario
                    where hf.IdFuncionario == idFuncionario
                    select hf
                ).ToListAsync();
        }
    }

    public async Task<int> HorarioFuncionarioIntervalo(int idFuncionario, DateTime dtAgendamento, TimeOnly tempoAgendado)
    {
        using (var banco = new AppDbContext(_context))
        {
            DateTime horarioFinal = dtAgendamento.AddHours(tempoAgendado.Hour).AddMinutes(tempoAgendado.Minute);

            return await (
                from hf in banco.HorarioFuncionario
                where hf.IdFuncionario == idFuncionario
                && hf.DataHorario >= horarioFinal
                select hf
            ).CountAsync();
        }
    }

    public async Task<IList<HorarioFuncionario>> ListaHorariosFuncionarioPeriodo(int idFuncionario, DateTime dtInicio, DateTime dtFim)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from hf in banco.HorarioFuncionario
                where hf.IdFuncionario == idFuncionario &&
                      hf.DataHorario >= dtInicio &&
                      hf.DataHorario <= dtFim
                select hf
            ).ToListAsync();
        }
    }
}
