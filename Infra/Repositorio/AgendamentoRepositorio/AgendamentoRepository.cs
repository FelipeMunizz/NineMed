using Domain.Interfaces.IAgendamento;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.AgendamentoRepositorio;

public class AgendamentoRepository : RepositorioGenerico<Agendamento>, InterfaceAgendamento
{
    private readonly DbContextOptions<AppDbContext> _context;

    public AgendamentoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<Agendamento>> ListaAgendamentosCliente(int idPaciente)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from a in banco.Agendamento
                where a.IdPaciente == idPaciente
                select a
                ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<IList<Agendamento>> ListaAgendamentosClinica(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from a in banco.Agendamento
                where a.IdClinica == idClinica
                select a
                ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<IList<Agendamento>> ListaAgendamentosDia(int idClinica, DateTime dia)
    {
        using (var banco = new AppDbContext(_context))
        {
            DateTime inicioDia = dia.Date; 
            DateTime fimDia = dia.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            return await (
                from a in banco.Agendamento
                where a.IdClinica == idClinica
                && a.DataAgendamento >= inicioDia
                && a.DataAgendamento <= fimDia
                select a
            ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<IList<Agendamento>> ListaAgendamentosFuncionario(int idFuncionario)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await(
                from a in banco.Agendamento
                where a.IdFuncionario.Equals(idFuncionario)
                select a
                ).AsNoTracking().ToListAsync();
        }
    }
}
