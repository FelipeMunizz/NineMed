using Domain.Interfaces.IConvenio;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.ConvenioRepositorio;

public class PlanosConvenioRepository : RepositorioGenerico<PlanosConvenio>, InterfacePlanosConvenio
{
    private readonly DbContextOptions<AppDbContext> _context;

    public PlanosConvenioRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<PlanosConvenio>> ListaPlanoConvenios(int idConvenio)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await(
                from pc in banco.PlanosConvenio
                where pc.IdConvenio.Equals(idConvenio)
                select pc
                ).AsNoTracking().ToListAsync();
        }
    }
}
