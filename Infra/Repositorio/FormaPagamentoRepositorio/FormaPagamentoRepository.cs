using Domain.Interfaces.IFormaPagamento;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio.FormaPagamentoRepositorio;

public class FormaPagamentoRepository : RepositorioGenerico<FormaPagamento>, InterfaceFormaPagamento
{
    private readonly DbContextOptions<AppDbContext> _context;

    public FormaPagamentoRepository(AppDbContext context)
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<FormaPagamento>> ListaFormaPagamentoClinica(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from fp in banco.FormaPagamento
                where fp.IdClinica.Equals(idClinica)
                select fp
                ).AsNoTracking().ToListAsync();
        }
    }
}
