using Domain.Interfaces.IAtendimento;
using Entities.Models;
using Entities.ModelsReports;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.AtendimentoRepositorio;

public class AtestadoAtendimentoRepository : RepositorioGenerico<AtestadoAtendimento>, InterfaceAtestadoAtendimento
{
    private readonly DbContextOptions<AppDbContext> _context;

    public AtestadoAtendimentoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<AtestadoAtendimento>> ListaAtestadoAtendimento(int idAtendimento)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await(
                    from aa in banco.AtestadoAtendimento
                    where aa.IdAtendimento == idAtendimento
                    select aa
                ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<AtestadoModelReport> GetAtestadoReport(int idAtendimento)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
            from a in banco.Atendimento
            join ag in banco.Agendamento on a.IdAgendamento equals ag.Id into agJoin
            from ag in agJoin.DefaultIfEmpty()
            join f in banco.Funcionario on ag.IdFuncionario equals f.Id into fJoin
            from f in fJoin.DefaultIfEmpty()
            join ata in banco.AtestadoAtendimento on a.Id equals ata.IdAtendimento into ataJoin
            from ata in ataJoin.DefaultIfEmpty()
            where a.Id == idAtendimento
            select new AtestadoModelReport
            {
                NomeFuncionario = f.Nome,
                DataAtestado = ata.Data,
                Descricao = ata.Descricao
            }
        ).FirstOrDefaultAsync();
        }
    }
}
