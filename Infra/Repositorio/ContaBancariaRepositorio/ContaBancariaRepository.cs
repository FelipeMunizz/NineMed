using Domain.Interfaces.IContaBancaria;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.ContaBancariaRepositorio;

public class ContaBancariaRepository : RepositorioGenerico<ContaBancaria>, InterfaceContaBancaria
{
    private readonly DbContextOptions<AppDbContext> _context;

    public ContaBancariaRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<ContaBancaria>> ListaContasBancariaBanco(int idBanco)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await(
                from b in banco.ContaBancaria
                where b.IdBanco.Equals(idBanco)
                select b
                ).AsNoTracking().ToListAsync();
        }
    }
}
