using Domain.Interfaces.IAgendamento;
using Entities.Enums;
using Entities.Models;
using Entities.Retorno;
using Helper.Configuracoes;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;

namespace Infra.Repositorio.AgendamentoRepositorio;

public class AgendamentoRepository : RepositorioGenerico<Agendamento>, InterfaceAgendamento
{
    private readonly DbContextOptions<AppDbContext> _context;

    public AgendamentoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<Agendamento>> ListaAgendamentosCliente(int idPaciente)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from a in banco.Agendamento
                where a.IdPaciente == idPaciente
                select a
                ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<IList<Agendamento>> ListaAgendamentosClinica(int idClinica)
    {
        IList<Agendamento> agendamentos = new List<Agendamento>();

        using (var connection = new SqlConnection(Config.ConectionString))
        {
            await connection.OpenAsync();
            string query = @"
        SELECT *
        FROM agendamento
        WHERE IdClinica = @IdClinica
    ";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdClinica", idClinica);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        TimeSpan horaAgendamentoSpan = TimeSpan.Zero;

                        List<int> ids = reader.GetString(reader.GetOrdinal("IdsProcedimento"))
                            .Replace("[", "")
                            .Replace("]", "")
                            .Split(',')
                            .Select(int.Parse)
                            .ToList();
                        int[] idsProcedimentos = ids.ToArray();

                        horaAgendamentoSpan = reader.GetTimeSpan(reader.GetOrdinal("HoraAgendamento"));
                        var agendamento = new Agendamento
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            DataAgendamento = reader.GetDateTime(reader.GetOrdinal("DataAgendamento")),
                            Repeticao = (RepeticaoAgendamento)reader.GetInt32(reader.GetOrdinal("Repeticao")),
                            SituacaoAgendamento = (SituacaoAgendamento)reader.GetInt32(reader.GetOrdinal("SituacaoAgendamento")),
                            Lembrete = reader.GetBoolean(reader.GetOrdinal("Lembrete")),
                            Observacao = reader.IsDBNull(reader.GetOrdinal("Observacao")) ? null : reader.GetString(reader.GetOrdinal("Observacao")),
                            IdClinica = reader.GetInt32(reader.GetOrdinal("IdClinica")),
                            IdPaciente = reader.GetInt32(reader.GetOrdinal("IdPaciente")),
                            IdFuncionario = reader.GetInt32(reader.GetOrdinal("IdFuncionario")),
                            IdConvenio = reader.GetInt32(reader.GetOrdinal("IdConvenio")),
                            IdsProcedimento = idsProcedimentos
                        };

                        agendamento.HoraAgendamento = new TimeOnly(horaAgendamentoSpan.Hours, horaAgendamentoSpan.Minutes, horaAgendamentoSpan.Seconds);

                        agendamentos.Add(agendamento);
                    }
                }
            }
        }

        return agendamentos;
    }

    public async Task<IList<Agendamento>> ListaAgendamentosDia(int idClinica, DateTime dia)
    {
        using (var connection = new SqlConnection(Config.ConectionString))
        {
            await connection.OpenAsync();
            string query = $@"
            SELECT *
            FROM agendamento
            WHERE IdClinica = @IdClinica
            AND DataAgendamento >= @InicioDia
            AND DataAgendamento <= @FimDia
        ";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdClinica", idClinica);
                command.Parameters.AddWithValue("@InicioDia", dia.Date);
                command.Parameters.AddWithValue("@FimDia", dia.Date.AddHours(23).AddMinutes(59).AddSeconds(59));

                var agendamentos = new List<Agendamento>();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        TimeSpan horaAgendamentoSpan = TimeSpan.Zero;

                        List<int> ids = reader.GetString(reader.GetOrdinal("IdsProcedimento"))
                            .Replace("[", "")
                            .Replace("]", "")
                            .Split(',')
                            .Select(int.Parse)
                            .ToList();
                        int[] idsProcedimentos = ids.ToArray();

                        horaAgendamentoSpan = reader.GetTimeSpan(reader.GetOrdinal("HoraAgendamento"));
                        var agendamento = new Agendamento
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            DataAgendamento = reader.GetDateTime(reader.GetOrdinal("DataAgendamento")),
                            Repeticao = (RepeticaoAgendamento)reader.GetInt32(reader.GetOrdinal("Repeticao")),
                            SituacaoAgendamento = (SituacaoAgendamento)reader.GetInt32(reader.GetOrdinal("SituacaoAgendamento")),
                            Lembrete = reader.GetBoolean(reader.GetOrdinal("Lembrete")),
                            Observacao = reader.IsDBNull(reader.GetOrdinal("Observacao")) ? null : reader.GetString(reader.GetOrdinal("Observacao")),
                            IdClinica = reader.GetInt32(reader.GetOrdinal("IdClinica")),
                            IdPaciente = reader.GetInt32(reader.GetOrdinal("IdPaciente")),
                            IdFuncionario = reader.GetInt32(reader.GetOrdinal("IdFuncionario")),
                            IdConvenio = reader.GetInt32(reader.GetOrdinal("IdConvenio")),
                            IdsProcedimento = idsProcedimentos
                        };

                        agendamento.HoraAgendamento = new TimeOnly(horaAgendamentoSpan.Hours, horaAgendamentoSpan.Minutes, horaAgendamentoSpan.Seconds);

                        agendamentos.Add(agendamento);
                    }
                }

                return agendamentos;
            }
        }
    }

    public async Task<IList<Agendamento>> ListaAgendamentosFuncionario(int idFuncionario)
    {
        using (var connection = new SqlConnection(Config.ConectionString))
        {
            await connection.OpenAsync();
            string query = $@"
            SELECT *
            FROM agendamento
            WHERE IdFuncionario = @IdFuncionario
        ";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdFuncionario", idFuncionario);

                var agendamentos = new List<Agendamento>();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        TimeSpan horaAgendamentoSpan = TimeSpan.Zero;

                        List<int> ids = reader.GetString(reader.GetOrdinal("IdsProcedimento"))
                            .Replace("[", "")
                            .Replace("]", "")
                            .Split(',')
                            .Select(int.Parse)
                            .ToList();
                        int[] idsProcedimentos = ids.ToArray();

                        horaAgendamentoSpan = reader.GetTimeSpan(reader.GetOrdinal("HoraAgendamento"));
                        var agendamento = new Agendamento
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            DataAgendamento = reader.GetDateTime(reader.GetOrdinal("DataAgendamento")),
                            Repeticao = (RepeticaoAgendamento)reader.GetInt32(reader.GetOrdinal("Repeticao")),
                            SituacaoAgendamento = (SituacaoAgendamento)reader.GetInt32(reader.GetOrdinal("SituacaoAgendamento")),
                            Lembrete = reader.GetBoolean(reader.GetOrdinal("Lembrete")),
                            Observacao = reader.IsDBNull(reader.GetOrdinal("Observacao")) ? null : reader.GetString(reader.GetOrdinal("Observacao")),
                            IdClinica = reader.GetInt32(reader.GetOrdinal("IdClinica")),
                            IdPaciente = reader.GetInt32(reader.GetOrdinal("IdPaciente")),
                            IdFuncionario = reader.GetInt32(reader.GetOrdinal("IdFuncionario")),
                            IdConvenio = reader.GetInt32(reader.GetOrdinal("IdConvenio")),
                            IdsProcedimento = idsProcedimentos
                        };

                        agendamento.HoraAgendamento = new TimeOnly(horaAgendamentoSpan.Hours, horaAgendamentoSpan.Minutes, horaAgendamentoSpan.Seconds);

                        agendamentos.Add(agendamento);
                    }
                }

                return agendamentos;
            }
        }
    }

    public async Task<RetornoGenerico<object>> GraficoAgendamento(int idClinica)
    {
        try
        {
            using (var banco = new AppDbContext(_context))
            {
                var enumDescriptions = Enum.GetValues(typeof(SituacaoAgendamento))
                                .Cast<SituacaoAgendamento>()
                                .ToDictionary(e => e.ToString(), e => EnumHelper.GetEnumDescription(e));

                var resultado = await (
                    from a in banco.Agendamento
                    where a.DataAgendamento >= DateTime.Now.AddDays(-30)
                       && a.DataAgendamento <= DateTime.Now
                    group a by a.SituacaoAgendamento into g
                    select new
                    {
                        Name = enumDescriptions.ContainsKey(g.Key.ToString()) ? enumDescriptions[g.Key.ToString()] : g.Key.ToString(),
                        Value = g.Count()
                    }
            ).AsNoTracking().ToListAsync();

                return new RetornoGenerico<object>
                {
                    Success = true,
                    Message = "Gerado com Sucesso",
                    Result = resultado
                };
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    public static class EnumHelper
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}