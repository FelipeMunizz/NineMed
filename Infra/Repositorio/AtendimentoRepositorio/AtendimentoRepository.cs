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
        string query = $@"
                        WITH Registros AS (
                SELECT 
                    a.Id AS CodRegistro,
                    'Atendimento' AS TipoRegistro,
                    CONCAT(FORMAT(ag.[DataAgendamento], 'dd/MM/yyyy'), ' ', ag.[HoraAgendamento]) AS DataRegistro,
                    a.[QueixaPrincipal] AS Descricao
                FROM Atendimento a
                JOIN Agendamento ag ON a.IdAgendamento = ag.Id
                JOIN Paciente p ON p.Id = ag.IdPaciente
                WHERE p.Id = {idPaciente}

                UNION ALL

                SELECT 
                    ax.Id AS CodRegistro,
                    'Anexos' AS TipoRegistro,
                    CONCAT(FORMAT(ag.[DataAgendamento], 'dd/MM/yyyy'), ' ', ag.[HoraAgendamento]) AS DataRegistro,
                    ax.Base64Anexo AS Descricao
                FROM AnexosAtendimento ax
                JOIN Atendimento a ON a.Id = ax.IdAtendimento
                JOIN Agendamento ag ON a.Id = a.IdAgendamento
                JOIN Paciente p ON p.Id = ag.IdPaciente
                WHERE p.Id = {idPaciente}

                UNION ALL

                SELECT 
                    ats.Id AS CodRegistro,
                    'Atestado' AS TipoRegistro,
                    CONCAT(FORMAT(ag.[DataAgendamento], 'dd/MM/yyyy'), ' ', ag.[HoraAgendamento]) AS DataRegistro,
                    ats.Descricao AS Descricao
                FROM AtestadoAtendimento ats
                JOIN Atendimento a ON a.Id = ats.IdAtendimento
                JOIN Agendamento ag ON a.Id = a.IdAgendamento
                JOIN Paciente p ON p.Id = ag.IdPaciente
                WHERE p.Id = {idPaciente}

                UNION ALL

                SELECT 
                    ex.Id AS CodRegistro,
                    'Exame' AS TipoRegistro,
                    CONCAT(FORMAT(ag.[DataAgendamento], 'dd/MM/yyyy'), ' ', ag.[HoraAgendamento]) AS DataRegistro,
                    ex.Exame AS Descricao
                FROM ExameAtendimento ex
                JOIN Atendimento a ON a.Id = ex.IdAtendimento
                JOIN Agendamento ag ON a.Id = a.IdAgendamento
                JOIN Paciente p ON p.Id = ag.IdPaciente
                WHERE p.Id = {idPaciente}

                UNION ALL

                SELECT 
                    prs.Id AS CodRegistro,
                    'Prescrição' AS TipoRegistro,
                    CONCAT(FORMAT(ag.[DataAgendamento], 'dd/MM/yyyy'), ' ', ag.[HoraAgendamento]) AS DataRegistro,
                    prs.ItemReceita AS Descricao
                FROM PrescricaoAtendimento prs
                JOIN Atendimento a ON a.Id = prs.IdAtendimento
                JOIN Agendamento ag ON a.Id = a.IdAgendamento
                JOIN Paciente p ON p.Id = ag.IdPaciente
                WHERE p.Id = {idPaciente}
            )
            SELECT 
                CodRegistro,
                TipoRegistro,
                DataRegistro,
                Descricao
            FROM Registros
            ORDER BY DataRegistro;
            
            ";

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
