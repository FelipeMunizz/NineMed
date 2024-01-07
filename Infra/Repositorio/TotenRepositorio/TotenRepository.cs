using Domain.Interfaces.IToten;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Infra.Repositorio.TotenRepositorio;

public class TotenRepository : RepositorioGenerico<Toten>, InterfaceToten
{
    private readonly DbContextOptions<AppDbContext> _context;

    public TotenRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<Toten>> ListaTotensClinica(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await(
                    from t in banco.Toten
                    where t.IdClinica.Equals(idClinica)
                    select t
                    ).ToListAsync();
        }
    }
}
