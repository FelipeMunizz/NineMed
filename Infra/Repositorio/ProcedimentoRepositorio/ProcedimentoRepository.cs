using Domain.Interfaces.IProcedimento;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.ProcedimentoRepositorio;

public class ProcedimentoRepository : RepositorioGenerico<Procedimento>, InterfaceProcedimento
{
    private readonly DbContextOptions<AppDbContext> _context;

    public ProcedimentoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<Procedimento>> ListaProcedimentoClinica(int idClinica)
    {
        using(var banco = new AppDbContext(_context))
        {
            return await (
                from p in banco.Procedimento
                join c in banco.Clinica on p.IdClinica equals c.Id
                where c.Id == idClinica
                select p
                ).AsNoTracking().ToListAsync();
        }
    }
}
