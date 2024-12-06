using Domain.Interfaces.IAtendimento;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.AtendimentoRepositorio;

public class AtestadoAtendimentoRepository : RepositorioGenerico<AtestadoAtendimento>, InterfaceAtestadoAtendimento
{
    private readonly DbContextOptions<AppDbContext> _context;

    public AtestadoAtendimentoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<AtestadoAtendimento>> ListaAtestadoAtendimento(int idAtendimento)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await(
                    from aa in banco.AtestadoAtendimento
                    where aa.IdAtendimento == idAtendimento
                    select aa
                ).AsNoTracking().ToListAsync();
        }
    }
}
