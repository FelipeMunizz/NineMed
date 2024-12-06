using Domain.Interfaces.IPaciente;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.PacienteRepositorio;

public class PacienteProntuarioRepository : RepositorioGenerico<PacienteProntuario>, InterfacePacienteProntuario
{
    private readonly DbContextOptions<AppDbContext> _context;

    public PacienteProntuarioRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<PacienteProntuario> ObtemPacienteProntuario(int idPaciente)
    {
        using(var banco = new AppDbContext(_context))
        {
            return await (
                    from pp in banco.ProntuarioPaciente
                    where pp.IdPaciente == idPaciente
                    select pp
                ).AsNoTracking().FirstOrDefaultAsync();
        }
    }

    public async Task<object> ObtemProntuarioTelaAtendimento(int idPaciente)
    {
        using (var banco = new AppDbContext(_context))
        {
            var resultado = await (
                from p in banco.Paciente
                join pc in banco.PacienteConvenio on p.Id equals pc.IdPaciente
                join c in banco.Convenio on pc.IdConvenio equals c.Id
                join pp in banco.ProntuarioPaciente on p.Id equals pp.IdPaciente
                join a in banco.Agendamento on p.Id equals a.IdPaciente into agendamentos
                from ag in agendamentos.DefaultIfEmpty()
                where p.Id == idPaciente
                group new { p, c, pp, ag } by new
                {
                    p.Nome,
                    p.DataNascimento,
                    Convenio = c.NomeFantasia ?? c.Nome,
                    pp.AntecedenteClinico,
                    pp.AntecedenteCirurgico,
                    pp.AntecedenteFamiliares,
                    pp.Habitos,
                    pp.Alergias,
                    pp.MedicamentoUso
                } into g
                select new
                {
                    Nome = !string.IsNullOrEmpty(g.Key.Nome) ? g.Key.Nome : string.Empty,
                    DataNascimento = g.Key.DataNascimento,
                    Convenio = !string.IsNullOrEmpty(g.Key.Convenio) ? g.Key.Convenio : string.Empty,
                    PrimeiraConsulta = g.Min(x => x.ag.DataAgendamento) != null ? g.Min(x => x.ag.DataAgendamento).ToString("dd/MM/yyyy") : "Sem Registros",
                    AntecedenteClinico = !string.IsNullOrEmpty(g.Key.AntecedenteClinico) ? g.Key.AntecedenteClinico : string.Empty,
                    AntecedenteCirurgico = !string.IsNullOrEmpty(g.Key.AntecedenteCirurgico) ? g.Key.AntecedenteCirurgico : string.Empty,
                    AntecedenteFamiliares = !string.IsNullOrEmpty(g.Key.AntecedenteFamiliares) ? g.Key.AntecedenteFamiliares : string.Empty,
                    Habitos = !string.IsNullOrEmpty(g.Key.Habitos) ? g.Key.Habitos : string.Empty,
                    Alergias = !string.IsNullOrEmpty(g.Key.Alergias) ? g.Key.Alergias : string.Empty,
                    MedicamentoUso = !string.IsNullOrEmpty(g.Key.MedicamentoUso) ? g.Key.MedicamentoUso : string.Empty
                }
            ).AsNoTracking().FirstOrDefaultAsync();

            return resultado;
        }
    }

}
