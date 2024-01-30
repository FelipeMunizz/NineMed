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
}
