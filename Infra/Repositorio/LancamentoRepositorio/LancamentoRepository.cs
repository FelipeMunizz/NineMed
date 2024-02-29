using Domain.Interfaces.ILancamento;
using Entities.Enums;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.LancamentoRepositorio;

public class LancamentoRepository : RepositorioGenerico<Lancamento>, InterfaceLancamento
{
    private readonly DbContextOptions<AppDbContext> _context;

    public LancamentoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<Lancamento>> ListaLancamentoDespesas(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            TipoLancamento tipo = TipoLancamento.Despesa;
            return await(
                from l in banco.Lancamento
                where l.IdClinica.Equals(idClinica) && l.Tipo.Equals(tipo)
                select l
                ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<IList<Lancamento>> ListaLancamentoReceitas(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            TipoLancamento tipo = TipoLancamento.Receita;

            return await(
                from l in banco.Lancamento
                where l.IdClinica.Equals(idClinica) && l.Tipo.Equals(tipo)
                select l
                ).AsNoTracking().ToListAsync();
        }
    }
}
