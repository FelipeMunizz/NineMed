using Domain.Interfaces.IAtendimento;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

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
}
