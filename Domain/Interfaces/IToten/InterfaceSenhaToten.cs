using Domain.Interfaces.Generics;
using Entities.Enums;
using Entities.Models;

namespace Domain.Interfaces.IToten;

public interface InterfaceSenhaToten : InterfaceGeneric<SenhaToten>
{
    Task<IList<SenhaToten>> ListaSenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento, int idToten);
    Task<IList<SenhaToten>> ListaSenhasPainel(int idToten);
    Task<int> SenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento, int idToten);
    Task<SenhaToten> ObtemSenhaPainel(string senhaPainel, int idToten);
    Task<IList<SenhaToten>> SenhasParaExcluir(DateTime diaAnterior, int idToten);
}
