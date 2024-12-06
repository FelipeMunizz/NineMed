using Domain.Interfaces.ISubCategoria;
using Entities.Enums;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.SubCategoriaRepositorio;

public class SubCategoriaRepository : RepositorioGenerico<SubCategoria>, InterfaceSubCategoria
{
    private readonly DbContextOptions<AppDbContext> _context;

    public SubCategoriaRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<SubCategoria>> ListarSubCategoriaFinanceiras(int idCategoriaFinanceira)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from sc in banco.SubCategoria
                where sc.IdCategoriaFinanceira.Equals(idCategoriaFinanceira)
                select sc
                ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<IList<SubCategoria>> ListaSubCategoriaTipo(TipoLancamento tipo, int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from sc in banco.SubCategoria
                join c in banco.CategoriaFinanceira on sc.IdCategoriaFinanceira equals c.Id
                where c.Tipo.Equals(tipo) && c.IdClinica.Equals(idClinica)
                select sc
                ).AsNoTracking().ToListAsync();
        }
    }
}
