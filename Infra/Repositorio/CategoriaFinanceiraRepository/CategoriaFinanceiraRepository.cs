using Domain.Interfaces.ICategoriaFinanceira;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.CategoriaFinanceiraRepository;

public class CategoriaFinanceiraRepository : RepositorioGenerico<CategoriaFinanceira>, InterfaceCategoriaFinanceira
{
    private readonly DbContextOptions<AppDbContext> _context;

    public CategoriaFinanceiraRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<CategoriaFinanceira>> ListarCategoriasFinanceiraClinica(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from cf in banco.CategoriaFinanceira
                where cf.IdClinica.Equals(idClinica)
                select cf
                ).AsNoTracking().ToListAsync();
        }
    }
}
