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
            from ats in banco.AtestadoAtendimento
            join at in banco.Atendimento on ats.IdAtendimento equals at.Id
            join ag in banco.Agendamento on at.IdAgendamento equals ag.Id
            join f in banco.Funcionario on ag.IdFuncionario equals f.Id
            join p in banco.Paciente on ag.IdPaciente equals p.Id
            join c in banco.Clinica on ag.IdClinica equals c.Id
            let endereco = banco.EnderecoClinica
                            .Where(ed => ed.IdClinica == c.Id)
                            .OrderBy(ed => ed.Id)
                            .FirstOrDefault()
            let contato = banco.ContatoClinica
                            .Where(ct => ct.IdClinica == c.Id)
                            .OrderBy(ct => ct.Id)
                            .FirstOrDefault()
            where ats.IdAtendimento == idAtendimento
            select new AtestadoModelReport
            {
                NomePaciente = p.Nome,
                NomeFuncionario = f.Nome,
                NomeEmpresa = c.Nome ?? c.Fantasia ?? c.RazaoSocial,
                DataFinal = ats.Data,
                Descricao = ats.Descricao,
                CRM = "",
                UF = endereco.Estado,
                Endereco = endereco != null ? $"{endereco.Logradouro}, {endereco.Numero}" : null,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Telefone = contato.NumeroContato
            }
        ).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
