using Domain.Interfaces.IConvenio;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.ConvenioRepositorio;

public class ConvenioRepository : RepositorioGenerico<Convenio>, InterfaceConvenio
{
    private readonly DbContextOptions<AppDbContext> _context;

    public ConvenioRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<Convenio>> ListaConveniosClinica(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await(
                from c in banco.Convenio
                where c.IdClinica.Equals(idClinica)
                select c
                ).AsNoTracking().ToListAsync();
        }
    }
}
