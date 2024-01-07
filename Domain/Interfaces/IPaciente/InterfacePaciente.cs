using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IPaciente;

public interface InterfacePaciente : InterfaceGeneric<Paciente> 
{
    Task<IList<Paciente>> ListaPacienteClinica(int idClinica);
}
