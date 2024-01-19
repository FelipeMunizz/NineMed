using Domain.Interfaces.IAgendamento;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.AgendamentoRepositorio;

public class AgendamentoProcedimentoRepository : RepositorioGenerico<AgendamentoProcedimento>, InterfaceAgendamentoProcedimento
{
    private readonly DbContextOptions<AppDbContext> _context;

    public AgendamentoProcedimentoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<AgendamentoProcedimento>> ListaAgendamentosProcedimento(int idAgendamento)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await(
                from ap in banco.AgendamentoProcedimento
                join a in banco.Agendamento on ap.IdAgendamento equals a.Id
                where a.Id.Equals(idAgendamento)
                select ap
                ).AsNoTracking().ToListAsync();
        }
    }
}
