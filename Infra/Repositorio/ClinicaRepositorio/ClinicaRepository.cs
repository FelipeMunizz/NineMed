using Domain.Interfaces.IClinica;
using Infra.Configuracao;
using Entities.Models;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.ClinicaRepositorio;

public class ClinicaRepository : RepositorioGenerico<Clinica>, InterfaceClinica
{
    private readonly DbContextOptions<AppDbContext> _context;

    public ClinicaRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<Clinica>> ListaClinicasUsuario(string email)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from c in banco.Clinica
                join f in banco.Funcionario on c.Id equals f.IdClinica
                where f.Email.Equals(email)
                select c
                ).AsNoTracking().ToListAsync();
        }
    }
}
