using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IClinica;

public  interface InterfaceEnderecoClinica : InterfaceGeneric<EnderecoClinica>
{
    Task<IList<EnderecoClinica>> EnderecosClinica(int idClinica);
}
