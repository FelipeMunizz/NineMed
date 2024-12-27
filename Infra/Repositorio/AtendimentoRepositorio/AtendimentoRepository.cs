using Dapper;
using Domain.Interfaces.IAtendimento;
using Entities.Models;
using Entities.Retorno;
using Helper.Configuracoes;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Infra.Repositorio.AtendimentoRepositorio;

public class AtendimentoRepository : RepositorioGenerico<Atendimento>, InterfaceAtendimento
{
    private readonly DbContextOptions<AppDbContext> _context;

    public AtendimentoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<Atendimento>> ListaAtentedimentoPaciente(int idPaciente)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from a in banco.Atendimento
                join ag in banco.Agendamento on a.IdAgendamento equals ag.Id
                where ag.IdPaciente == idPaciente
                select a
                ).AsNoTracking().ToListAsync();
        }
    }
    public async Task<RetornoGenerico<object>> GraficoAtendimentosMensal(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            var resultados = await (
                from ate in banco.Atendimento
                join ag in banco.Agendamento on ate.IdAgendamento equals ag.Id
                join c in banco.Clinica on ag.IdClinica equals c.Id
                where c.Id == idClinica
                group ate by new { Mes = ag.DataAgendamento.Month } into grp
                orderby grp.Key.Mes descending
                select new
                {
                    Mes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(grp.Key.Mes),
                    QuantidadeAgendamento = grp.Count()
                }
            ).Take(5).AsNoTracking().ToListAsync();

            return new RetornoGenerico<object>
            {
                Success = true,
                Message = "Gerado com sucesso",
                Result = resultados
            };
        }
    }

    public async Task<Atendimento?> ObterAtendimentoAgendamento(int idAgendamento)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from a in banco.Atendimento
                where a.IdAgendamento == idAgendamento
                select a
                ).AsNoTracking().FirstOrDefaultAsync();
        }
    }

    public async Task<RetornoGenerico<object>> EvolucaoProntuarioByIdPaciente(int idPaciente)
    {
        string query = $"""
            SELECT 
                a.Id CodRegistro,
                'Atendimento' TipoRegistro,
                CONCAT(FORMAT(ag.[DataAgendamento], 'dd/MM/yyyy'), ' ', ag.[HoraAgendamento]) as DataRegistro,
                a.[QueixaPrincipal] as Descricao
            FROM Atendimento a
            join Agendamento ag on a.IdAgendamento = ag.Id
            join Paciente p on p.Id = ag.IdPaciente
            where p.Id = {idPaciente}
            and a.Finalizado = 1

            UNION ALL

            SELECT 
                ax.Id,
                'Anexos' TipoRegistro,
                CONCAT(FORMAT(ag.[DataAgendamento], 'dd/MM/yyyy'), ' ', ag.[HoraAgendamento]) as DataRegistro,
                ax.Base64Anexo
            FROM AnexosAtendimento ax
            JOIN Atendimento a on a.Id = ax.IdAtendimento
            JOIN Agendamento ag on a.Id = a.IdAgendamento
            join Paciente p on p.Id = ag.IdPaciente
            where p.Id = {idPaciente}
            and a.Finalizado = 1

            UNION ALL

            SELECT 
                ats.Id,
                'Atestado' TipoRegistro,
                CONCAT(FORMAT(ag.[DataAgendamento], 'dd/MM/yyyy'), ' ', ag.[HoraAgendamento]) as DataRegistro,
                ats.Descricao
            FROM AtestadoAtendimento ats
            JOIN Atendimento a on a.Id = ats.IdAtendimento
            JOIN Agendamento ag on a.Id = a.IdAgendamento
            join Paciente p on p.Id = ag.IdPaciente
            where p.Id = {idPaciente}
            and a.Finalizado = 1

            UNION ALL

            SELECT 
                ex.Id,
                'Exame' TipoRegistro,
                CONCAT(FORMAT(ag.[DataAgendamento], 'dd/MM/yyyy'), ' ', ag.[HoraAgendamento]) as DataRegistro,
                ex.Exame Descricao
            FROM ExameAtendimento ex
            JOIN Atendimento a on a.Id = ex.IdAtendimento
            JOIN Agendamento ag on a.Id = a.IdAgendamento
            join Paciente p on p.Id = ag.IdPaciente
            where p.Id = {idPaciente}
            and a.Finalizado = 1

            UNION ALL

            SELECT 
                prs.Id,
                'Prescrição' TipoRegistro,
                CONCAT(FORMAT(ag.[DataAgendamento], 'dd/MM/yyyy'), ' ', ag.[HoraAgendamento]) as DataRegistro,
                prs.ItemReceita Descricao
            FROM PrescricaoAtendimento prs
            JOIN Atendimento a on a.Id = prs.IdAtendimento
            JOIN Agendamento ag on a.Id = a.IdAgendamento
            join Paciente p on p.Id = ag.IdPaciente
            where p.Id = {idPaciente}
            and a.Finalizado = 1
            """;

        using (var connection = new SqlConnection(Config.ConectionString))
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                await connection.OpenAsync();

            var result = await connection.QueryAsync<dynamic>(query);

            return new RetornoGenerico<object>
            {
                Success = true,
                Message = "Evoulção do prontuário do paciente",
                Result = result
            };
        }
    }
}
