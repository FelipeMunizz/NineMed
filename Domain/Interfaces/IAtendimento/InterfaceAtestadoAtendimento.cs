using Domain.Interfaces.Generics;
using Entities.Models;
using Entities.ModelsReports;

namespace Domain.Interfaces.IAtendimento;

public interface InterfaceAtestadoAtendimento : InterfaceGeneric<AtestadoAtendimento>
{
    Task<IList<AtestadoAtendimento>> ListaAtestadoAtendimento(int idAtendimento);
    Task<AtestadoModelReport> GetAtestadoReport(int idAtendimento);
}
