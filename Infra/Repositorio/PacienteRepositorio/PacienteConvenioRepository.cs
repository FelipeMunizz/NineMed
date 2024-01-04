using Domain.Interfaces.IPaciente;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.PacienteRepositorio;

public class PacienteConvenioRepository : RepositorioGenerico<PacienteConvenio>, InterfacePacienteConvenio
{
    private readonly DbContextOptions<AppDbContext> _context;

    public PacienteConvenioRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<PacienteConvenio>> ListaConveniosPaciente(int idPaciente)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await(
                from pc in banco.PacienteConvenio
                where pc.IdPaciente.Equals(idPaciente)
                select pc
                ).AsNoTracking().ToListAsync();
        }
    }
}
