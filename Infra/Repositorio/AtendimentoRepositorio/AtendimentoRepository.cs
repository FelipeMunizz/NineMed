using Domain.Interfaces.IAtendimento;
using Entities.Models;
using Entities.Retorno;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
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
            return await(
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
}
