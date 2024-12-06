using Domain.Interfaces.IPaciente;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.PacienteRepositorio;

public class PacienteFamiliarRepoistory : RepositorioGenerico<PacienteFamiliar>, InterfacePacienteFamiliar
{
    private readonly DbContextOptions<AppDbContext> _context;

    public PacienteFamiliarRepoistory(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<PacienteFamiliar>> ListaFamiliaresPaciente(int idPaciente)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await(
                from f in banco.PacienteFamiliar
                where f.IdPaciente.Equals(idPaciente)
                select f
                ).AsNoTracking().ToListAsync();
        }
    }
}
