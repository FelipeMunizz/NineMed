using Domain.Interfaces.IClinica;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.ClinicaRepositorio;

public class EnderecoClinicaRepository : RepositorioGenerico<EnderecoClinica>, InterfaceEnderecoClinica
{
    private readonly DbContextOptions<AppDbContext> _context;

    public EnderecoClinicaRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<EnderecoClinica>> EnderecosClinica(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from ec in banco.EnderecoClinica
                where ec.IdClinica.Equals(idClinica)
                select ec
                ).AsNoTracking().ToListAsync();
        }
    }
}
