using Domain.Interfaces.IAtendimento;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.AtendimentoRepositorio;

public class AnexosAtendimentoRepository : RepositorioGenerico<AnexosAtendimento>, InterfaceAnexosAtendimento
{
    private readonly DbContextOptions<AppDbContext> _context;

    public AnexosAtendimentoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<AnexosAtendimento>> ListaAnexosAtendimento(int idAtendimento)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await(
                    from aa in banco.AnexosAtendimento
                    where aa.IdAtendimento == idAtendimento
                    select aa
                ).AsNoTracking().ToListAsync();
        }
    }
}
