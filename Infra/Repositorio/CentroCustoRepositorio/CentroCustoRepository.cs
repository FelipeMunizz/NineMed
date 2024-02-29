using Domain.Interfaces.ICentroCusto;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.CentroCustoRepositorio;

public class CentroCustoRepository : RepositorioGenerico<CentroCusto>, InterfaceCentroCusto
{
    private readonly DbContextOptions<AppDbContext> _context;

    public CentroCustoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<CentroCusto>> ListarCentroCustoClinica(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from cc in banco.CentroCusto
                where cc.IdClinica.Equals(idClinica)
                select cc
                ).AsNoTracking().ToListAsync();
        }
    }
}
