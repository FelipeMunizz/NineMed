using Entities.Enums;
using Entities.Models;

namespace Domain.Interfaces.IToten;

public interface InterfaceSenhaToten
{
    Task<SenhaToten> AddSenhaToten(SenhaToten senhaToten);
    Task<SenhaToten> UpdateSenhaToten(SenhaToten senhaToten);
    Task DeletarSenhaToten(SenhaToten senhaToten);
    Task<IList<SenhaToten>> ListaSenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento, int idToten);
    Task<IList<SenhaToten>> ListaSenhasPainel(int idToten);
    Task<int> SenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento, int idToten);
    Task<SenhaToten> ObtemSenhaPainel(string senhaPainel, int idToten);
}
