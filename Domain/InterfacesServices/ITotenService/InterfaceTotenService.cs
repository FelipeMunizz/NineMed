using Entities.Enums;
using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.ITotenService;

public interface InterfaceTotenService
{
    Task AdicionarToten(Toten toten);
    Task AtualizarToten(Toten toten);
    Task DeletarToten(int idToten);
    Task<RetornoGenerico<SenhaToten>> AdicionarSenhaToten(SenhaToten obj);
    Task AtualizarSenhaToten(SenhaToten obj);
    Task DeletarSenhasTotenDiarias(int idToten);
    Task<IList<SenhaToten>> ListaSenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento, int idToten);
    Task<IList<SenhaToten>> ListaSenhasPainel(int idToten);
}
