using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IConvenio
{
    public interface InterfaceProfissionalSaudeConvenio : InterfaceGeneric<ProfissionaisSaudeConvenio>
    {
        Task<IList<ProfissionaisSaudeConvenio>> ListaProfissionaisConvenio(int idConvenio);
        Task<bool> ProfissionalAtendeConvenio(int idFuncionario, int idConvenio);

    }
}
