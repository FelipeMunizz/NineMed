using Domain.Interfaces.IPaciente;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.PacienteRepositorio;

public class PacienteRepository : RepositorioGenerico<Paciente>, InterfacePaciente
{
    private readonly DbContextOptions<AppDbContext> _context;

    public PacienteRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<Paciente>> ListaPacienteClinica(int idClinica)
    {
        using(var banco = new AppDbContext(_context))
        {
            return await (
                from p in banco.Paciente
                where p.IdClinica.Equals(idClinica)
                select p
                ).AsNoTracking().ToListAsync();
        }
    }
}
