using Domain.Interfaces.Generics;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IConvenio
{
    public interface InterfaceProfissionalSaudeConvenio : InterfaceGeneric<ProfissionaisSaudeConvenio>
    {
        Task<IList<ProfissionaisSaudeConvenio>> ListaProfissionaisConvenio(int idConvenio);
    }
}
