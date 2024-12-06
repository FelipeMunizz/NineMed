using Domain.Interfaces.IPaciente;
using Entities.Models;
using Entities.Retorno;
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

    public async Task<RetornoGenerico<object>> GraficoPacienteConvenio(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            var resultado = await (
                from p in banco.Paciente
                join pc in banco.PacienteConvenio on p.Id equals pc.IdPaciente
                join c in banco.Convenio on pc.IdConvenio equals c.Id
                where p.IdClinica == idClinica
                group c by c.Nome into cn
                select new
                {
                    Value = cn.Count(),
                    Name = cn.Key
                }
            ).AsNoTracking().ToListAsync();

            return new RetornoGenerico<object>
            {
                Success = true,
                Message = "Gerado com sucesso",
                Result = resultado
            };
        }
    }

    public async Task<IList<Paciente>> ListaPacienteClinica(int idClinica)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await (
                from p in banco.Paciente
                where p.IdClinica.Equals(idClinica)
                select p
                ).AsNoTracking().ToListAsync();
        }
    }
}
