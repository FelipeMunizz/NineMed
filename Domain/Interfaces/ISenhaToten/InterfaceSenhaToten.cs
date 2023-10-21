using Domain.Interfaces.Generics;
using Enities.Enums;
using Enities.Models;

namespace Domain.Interfaces.ISenhaToten;

public interface InterfaceSenhaToten : InterfaceGeneric<SenhaToten>
{
    Task<IList<SenhaToten>> ListaSenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento, string email);
    Task<IList<SenhaToten>> ListaSenhaTotenDiarias(DateTime diaAtual, string email);
}
