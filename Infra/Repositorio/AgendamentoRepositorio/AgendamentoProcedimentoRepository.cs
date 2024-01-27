using Domain.Interfaces.IAgendamento;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.AgendamentoRepositorio;

public class AgendamentoProcedimentoRepository : RepositorioGenerico<AtendimentoProcedimento>, InterfaceAgendamentoProcedimento
{
    private readonly DbContextOptions<AppDbContext> _context;

    public AgendamentoProcedimentoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
}
