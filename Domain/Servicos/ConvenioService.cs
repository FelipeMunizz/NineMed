using Domain.Interfaces.IConvenio;
using Domain.InterfacesServices.IConvenioService;
using Entities.Models;

namespace Domain.Servicos;

public class ConvenioService : InterfaceConvenioService
{
    private readonly InterfaceConvenio _convenio;

    public ConvenioService(InterfaceConvenio convenio)
    {
        _convenio = convenio;
    }

    public async Task AdicionarConvenio(Convenio convenio)
    {
        await _convenio.Add(convenio);
    }

    public async Task AtualizarConvenio(Convenio convenio)
    {
        await _convenio.Update(convenio);
    }

    public async Task DeletarConvenio(int idConvenio)
    {
        Convenio convenio = await _convenio.GetEntityById(idConvenio);
        if(convenio != null)
            await _convenio.Delete(convenio);
    }
}
