using Domain.Interfaces.IFuncionario;
using Entities.Models;
using Infra.Repositorio.Generico;

namespace Infra.Repositorio.FuncionarioRepositorio;

public class FuncionarioRepository : RepositorioGenerico<Funcionario>, InterfaceFuncionario
{
}
