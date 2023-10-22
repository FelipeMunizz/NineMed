using Domain.Interfaces.Generics;
using Entities.Enums;
using Entities.Models;

namespace Domain.Interfaces.ISenhaToten;

public interface InterfaceSenhaToten : InterfaceGeneric<SenhaToten>
{
    Task<IList<SenhaToten>> ListaSenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento);
    Task<int> SenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento);
    Task<SenhaToten> ObtemSenhaPainel(string senhaPainel);
    Task<IList<SenhaToten>> SenhasParaExcluir(DateTime diaAnterior);
}
