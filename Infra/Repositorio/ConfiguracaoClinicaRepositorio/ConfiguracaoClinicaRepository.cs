using Domain.Interfaces.IConfiguracaoClinica;
using Entities.Models;
using Infra.Repositorio.Generico;

namespace Infra.Repositorio.ConfiguracaoClinicaRepositorio;

public class ConfiguracaoClinicaRepository : RepositorioGenerico<ConfiguracaoClinica>, InterfaceConfiguracaoClinica
{
}
