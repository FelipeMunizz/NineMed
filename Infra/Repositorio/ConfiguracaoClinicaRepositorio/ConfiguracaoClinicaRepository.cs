using Domain.Interfaces.IConfiguracaoClinica;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.ConfiguracaoClinicaRepositorio;

public class ConfiguracaoClinicaRepository : RepositorioGenerico<ConfiguracaoClinica>, InterfaceConfiguracaoClinica
{
    private readonly DbContextOptions<AppDbContext> _context;

    public ConfiguracaoClinicaRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<ConfiguracaoClinica> ObterConfiguracaoClinica(int idClinica)
    {
        using(var banco = new AppDbContext(_context))
        {
            return await (
                from cc in banco.ConfiguracaoClinica
                where cc.IdClinica.Equals(idClinica)
                select cc
                ).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
