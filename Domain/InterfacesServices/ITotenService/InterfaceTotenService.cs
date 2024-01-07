using Entities.Models;

namespace Domain.InterfacesServices.ITotenService;

public interface InterfaceTotenService
{
    Task AdicionarToten(Toten toten);
    Task AtualizarToten(Toten toten);
    Task DeletarToten(int idToten);
    Task AdicionarSenhaToten(SenhaToten obj);
    Task AtualizarSenhaToten(SenhaToten obj);
    Task DeletarSenhasTotenDiarias(int idToten);
}
