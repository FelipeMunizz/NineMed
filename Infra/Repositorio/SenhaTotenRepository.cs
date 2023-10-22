using Domain.Interfaces.ISenhaToten;
using Entities.Enums;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio;

public class SenhaTotenRepository : RepositorioGenerico<SenhaToten>, InterfaceSenhaToten
{
    private readonly DbContextOptions<AppDbContext> _context;

    public SenhaTotenRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<SenhaToten>> ListaSenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                    from s in banco.SenhaToten
                    where s.TipoAtendimento.Equals(tipoAtendimento)
                    select s
                ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<SenhaToten> UltimaSenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento)
    {
        using(var banco = new AppDbContext(_context))
        {
            return await(
            from s in banco.SenhaToten
            where s.TipoAtendimento.Equals(tipoAtendimento)
            orderby s.Id descending
            select s
        ).FirstOrDefaultAsync();
        }
    }
}
