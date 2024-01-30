using Domain.Interfaces.Generics;
using Domain.Interfaces.IConvenio;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.ConvenioRepositorio;

public class ProfissionalSaudeConvenioRepository : RepositorioGenerico<ProfissionaisSaudeConvenio>, InterfaceProfissionalSaudeConvenio
{
    private readonly DbContextOptions<AppDbContext> _context;

    public ProfissionalSaudeConvenioRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<ProfissionaisSaudeConvenio>> ListaProfissionaisConvenio(int idConvenio)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from psc in banco.ProfissionaisSaudeConvenio
                where psc.IdConvenio.Equals(idConvenio)
                select psc
                ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<bool> ProfissionalAtendeConvenio(int idFuncionario, int idConvenio)
    {
        using (var banco = new AppDbContext(_context))
        {
            var profissional =
                await (
                    from psc in banco.ProfissionaisSaudeConvenio
                    where psc.IdConvenio == idConvenio
                    && psc.IdFuncionario == idFuncionario
                    select psc
                ).FirstOrDefaultAsync();

            if (profissional != null)
                return true;
            return false;
        }
    }
}
