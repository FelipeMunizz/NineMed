using Domain.Interfaces.Generics;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Interfaces.IPaciente;

public interface InterfacePaciente : InterfaceGeneric<Paciente> 
{
    Task<IList<Paciente>> ListaPacienteClinica(int idClinica);
    Task<RetornoGenerico<object>> GraficoPacienteConvenio(int idClinica);
}
