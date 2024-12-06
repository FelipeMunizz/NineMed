using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IClinica;

public interface InterfaceClinica : InterfaceGeneric<Clinica>
{
    Task<IList<Clinica>> ListaClinicasUsuario(string email);
}
