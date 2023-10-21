using Domain.Interfaces.ISenhaToten;
using Enities.Enums;
using Enities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;

namespace Infra.Repositorio;

public class SenhaTotenRepository : RepositorioGenerico<SenhaToten>, InterfaceSenhaToten
{
    private readonly AppDbContext _context;

    public SenhaTotenRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<IList<SenhaToten>> ListaSenhaTotenDiarias(DateTime diaAtual, string email)
    {
        throw new NotImplementedException();
    }

    public Task<IList<SenhaToten>> ListaSenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento, string email)
    {
        throw new NotImplementedException();
    }
}
