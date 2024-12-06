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
            return await (
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

            return await (
                from l in banco.Lancamento
                where l.IdClinica.Equals(idClinica) && l.Tipo.Equals(tipo)
                select l
                ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<decimal> RetornoSaldoGeral(int idContaBancaria)
    {
        using (var banco = new AppDbContext(_context))
        {
            var saldo = await(
            from lancamento in banco.Lancamento
            join contaBancaria in banco.ContaBancaria on lancamento.IdContaBancaria equals contaBancaria.Id
            where contaBancaria.Id == 1
            group lancamento by 1 into g
            select new
            {
                Receitas = g.Sum(x => x.Tipo == TipoLancamento.Receita ? x.Valor : 0),
                Despesas = g.Sum(x => x.Tipo == TipoLancamento.Despesa ? x.Valor : 0)
            }
        ).FirstOrDefaultAsync();

            return saldo != null ? saldo.Receitas - saldo.Despesas : 0;
        }
    }
}
