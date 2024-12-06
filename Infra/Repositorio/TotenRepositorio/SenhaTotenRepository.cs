using Domain.Interfaces.IToten;
using Entities.Enums;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.TotenRepositorio;

public class SenhaTotenRepository : RepositorioGenerico<SenhaToten>, InterfaceSenhaToten
{
    private readonly DbContextOptions<AppDbContext> _context;

    public SenhaTotenRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<SenhaToten>> ListaSenhasPainel(int idToten)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from s in banco.SenhaToten
                where 
                    s.IdToten == idToten && 
                    s.StatusAtendimento != StatusAtendimento.Chegada
                orderby s.DataHoraAtualizacao descending
                select s
                ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<IList<SenhaToten>> ListaSenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento, int idToten)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                    from s in banco.SenhaToten
                    where s.TipoAtendimento.Equals(tipoAtendimento)
                        && s.StatusAtendimento == StatusAtendimento.Chegada
                        && s.IdToten.Equals(idToten)
                    select s
                ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<SenhaToten> ObtemSenhaPainel(string senhaPainel, int idToten)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from s in banco.SenhaToten
                where s.SenhaPainel == senhaPainel && s.IdToten.Equals(idToten)
                select s
        ).FirstOrDefaultAsync();
        }
    }

    public async Task<IList<SenhaToten>> SenhasParaExcluir(DateTime diaAtual, int idToten)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from s in banco.SenhaToten
                where s.DataHoraCriacao.Date < DateTime.Now
                && s.StatusAtendimento == StatusAtendimento.Saida
                && s.IdToten.Equals(idToten)
                select s
            ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<int> SenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento, int idToten)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
            from s in banco.SenhaToten
            where s.TipoAtendimento.Equals(tipoAtendimento) && s.IdToten.Equals(idToten)
            select s
        ).CountAsync();
        }
    }
}
