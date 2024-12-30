using Domain.Interfaces.Generics;
using Entities.Models;
using Entities.ModelsReports;
using Entities.Retorno;

namespace Domain.Interfaces.IAtendimento;

public interface InterfaceAtestadoAtendimento : InterfaceGeneric<AtestadoAtendimento>
{
    Task<AtestadoAtendimento> ObterAtestadoByIdAtendimento(int idAtendimento);
    Task<AtestadoModelReport> GetAtestadoReport(int idAtendimento);
}
