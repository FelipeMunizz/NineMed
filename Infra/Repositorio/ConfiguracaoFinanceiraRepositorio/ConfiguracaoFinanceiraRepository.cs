using Domain.Interfaces.ICategoriaFinanceira;
using Domain.Interfaces.IConfiguracaoFinanceira;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.ConfiguracaoFinanceiraRepositorio;

public class ConfiguracaoFinanceiraRepository : RepositorioGenerico<ConfiguracaoFinanceira>, InterfaceConfiguracaoFinanceira
{
    private readonly DbContextOptions<AppDbContext> _context;

    public ConfiguracaoFinanceiraRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<ConfiguracaoFinanceira>> ListarConfiguracaoFinanceiraClinica(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from cf in banco.ConfiguracaoFinanceira
                where cf.IdClinica.Equals(idClinica)
                select cf
                ).AsNoTracking().ToListAsync();
        }
    }
}
