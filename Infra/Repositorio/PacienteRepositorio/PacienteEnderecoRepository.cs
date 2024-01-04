using Domain.Interfaces.IPaciente;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.PacienteRepositorio;

public class PacienteEnderecoRepository : RepositorioGenerico<EnderecoPaciente>, InterfacePacienteEndereco
{
    private readonly DbContextOptions<AppDbContext> _context;

    public PacienteEnderecoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<EnderecoPaciente>> ListaEnderecosPaciente(int idPaciente)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await(
                from ep in banco.EnderecoPaciente
                where ep.IdPaciente.Equals(idPaciente)
                select ep
                ).AsNoTracking().ToListAsync();
        }
    }
}
