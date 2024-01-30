using Dapper;
using Domain.Interfaces.IFuncionario;
using Entities.Models;
using Helper.Configuracoes;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.Data.SqlClient;
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
        using (var connection = new SqlConnection(Config.ConectionString))
        {
            DateTime horarioFinal = dtAgendamento.AddHours(tempoAgendado.Hour).AddMinutes(tempoAgendado.Minute);
            await connection.OpenAsync();

            string sql = @"
                        SELECT * FROM horariofuncionario
                        WHERE idFuncionario = @IdFuncionario
                        AND dataHorario BETWEEN @DataInicio AND @DataFim
                      ";
            var horarios = await connection.QueryAsync<Toten>(sql, new { IdFuncionario = idFuncionario, DataInicio = dtAgendamento, DataFim = horarioFinal });

            await connection.CloseAsync();

            return horarios.Count();
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
