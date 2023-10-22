using Domain.Interfaces.ISenhaToten;
using Entities.Enums;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio;

public class SenhaTotenRepository : RepositorioGenerico<SenhaToten>, InterfaceSenhaToten
{
    private readonly DbContextOptions<AppDbContext> _context;

    public SenhaTotenRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<SenhaToten>> ListaSenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                    from s in banco.SenhaToten
                    where s.TipoAtendimento.Equals(tipoAtendimento)
                    select s
                ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<SenhaToten> ObtemSenhaPainel(string senhaPainel)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from s in banco.SenhaToten
                where s.SenhaPainel == senhaPainel
                select s
        ).FirstOrDefaultAsync();
        }
    }

    public async Task<IList<SenhaToten>> SenhasParaExcluir(DateTime diaAtual)
    {
        using (var banco = new AppDbContext(_context))
        {
            DateTime inicioDoDiaAnterior = diaAtual.Date.AddDays(-1);
            DateTime fimDoDiaAnterior = diaAtual.Date.AddSeconds(-1);
            return await (
                from s in banco.SenhaToten
                where s.DataHoraCriacao.Date >= inicioDoDiaAnterior && s.DataHoraCriacao < fimDoDiaAnterior 
                && s.StatusAtendimento == StatusAtendimento.Saida
                select s
            ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<int> SenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
            from s in banco.SenhaToten
            where s.TipoAtendimento.Equals(tipoAtendimento)
            select s
        ).CountAsync();
        }
    }
}
