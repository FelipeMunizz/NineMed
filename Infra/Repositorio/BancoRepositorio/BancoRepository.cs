using Domain.Interfaces.IBanco;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.BancoRepositorio;

public class BancoRepository : RepositorioGenerico<Banco>, IBanco
{
    private readonly DbContextOptions<AppDbContext> _context;

    public BancoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<Banco>> ListaBancosClinica(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await(
                from b in banco.Banco
                where b.IdClinica.Equals(idClinica)
                select b
                ).AsNoTracking().ToListAsync();
        }
    }
}
