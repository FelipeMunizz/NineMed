using Domain.Interfaces.IAtendimento;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.AtendimentoRepositorio;

public class ExamesAtendimentoRepository : RepositorioGenerico<ExameAtendimento>, InterfaceExameAtendimento
{
    private readonly DbContextOptions<AppDbContext> _context;

    public ExamesAtendimentoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<ExameAtendimento>> ListaAxamesAtendimento(int idAtendimento)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                    from ea in banco.ExameAtendimento
                    where ea.IdAtendimento == idAtendimento
                    select ea
                ).AsNoTracking().ToListAsync();
        }
    }
}
