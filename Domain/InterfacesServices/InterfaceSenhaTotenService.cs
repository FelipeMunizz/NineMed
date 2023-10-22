using Entities.Models;

namespace Domain.InterfacesServices;

public interface InterfaceSenhaTotenService
{
    Task AdicionarSenhaToten(SenhaToten obj);
    Task AtualizarSenhaToten(SenhaToten obj);
    Task DeletarSenhasTotenDiarias();
}
