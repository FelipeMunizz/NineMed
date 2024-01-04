using Domain.Interfaces.IPaciente;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.PacienteRepositorio;

public class PacienteContatoRepository : RepositorioGenerico<ContatoPaciente>, InterfacePacienteContato
{
    private readonly DbContextOptions<AppDbContext> _context;

    public PacienteContatoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<ContatoPaciente>> ListaContatosPaciente(int idPaciente)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await(
                from cp in banco.ContatoPaciente
                where cp.IdPaciente.Equals(idPaciente)
                select cp
                ).AsNoTracking().ToListAsync();
        }
    }
}
