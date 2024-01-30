using Domain.Interfaces.IAtendimento;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.AtendimentoRepositorio;

public class PrescricaoAtendimentoRepository : RepositorioGenerico<PrescricaoAtendimento>, InterfacePrescricaoAtendimento
{
    private readonly DbContextOptions<AppDbContext> _context;

    public PrescricaoAtendimentoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<PrescricaoAtendimento>> ListaPrescricaoAtendimento(int idAtendimento)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                    from pa in banco.PrescricaoAtendimento
                    where pa.IdAtendimento == idAtendimento
                    select pa
                ).AsNoTracking().ToListAsync();
        }
    }
}
