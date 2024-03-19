using Domain.Interfaces.IFuncionario;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.FuncionarioRepositorio;

public class FuncionarioRepository : RepositorioGenerico<Funcionario>, InterfaceFuncionario
{
    private readonly DbContextOptions<AppDbContext> _context;

    public FuncionarioRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<Funcionario>> ListarFuncionariosClinica(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await(
                    from f in banco.Funcionario
                    where f.IdClinica.Equals(idClinica)
                    select f
                    ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<IList<Funcionario>> ListarProfissionaisSaude(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                    from f in banco.Funcionario
                    where f.IdClinica.Equals(idClinica) && f.ProfissionalSaude == true
                    select f
                    ).AsNoTracking().ToListAsync();
        }
    }

    public async Task<Funcionario> ObterFuncionarioEmail(string email)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                    from f in banco.Funcionario
                    where f.Email.Equals(email)
                    select f
                    ).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
