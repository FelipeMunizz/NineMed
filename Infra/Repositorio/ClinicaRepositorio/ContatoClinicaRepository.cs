using Domain.Interfaces.IClinica;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.ClinicaRepositorio;

public class ContatoClinicaRepository : RepositorioGenerico<ContatoClinica>, InterfaceContatoClinica
{
    private readonly DbContextOptions<AppDbContext> _context;

    public ContatoClinicaRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<ContatoClinica>> ContatosClinica(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from cc in banco.ContatoClinica
                where cc.IdClinica.Equals(idClinica)
                select cc
                ).AsNoTracking().ToListAsync();
        }
    }
}
