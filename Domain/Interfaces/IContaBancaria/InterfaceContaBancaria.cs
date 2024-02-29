using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IContaBancaria;

public interface InterfaceContaBancaria : InterfaceGeneric<ContaBancaria>
{
    Task<IList<ContaBancaria>> ListaContasBancariaBanco(int idBanco);
}
