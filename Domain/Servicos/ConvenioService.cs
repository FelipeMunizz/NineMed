using Domain.Interfaces.IConvenio;
using Domain.InterfacesServices.IConvenioService;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class ConvenioService : InterfaceConvenioService
{
    private readonly InterfaceConvenio _convenio;
    private readonly InterfacePlanosConvenio _planos;

    public ConvenioService(InterfaceConvenio convenio, InterfacePlanosConvenio planos)
    {
        _convenio = convenio;
        _planos = planos;
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

    public async Task<IList<PlanosConvenio>> ListaPlanosConvenio(int idConvenio) => await _planos.ListaPlanoConvenios(idConvenio);

    public async Task<PlanosConvenio> ObtemPlanoConvenio(int idPlanoConvenio) => await _planos.GetEntityById(idPlanoConvenio);
    public async Task<RetornoGenerico<object>> AdicionarPlanoConvenio(PlanosConvenio plano)
    {
        try
        {
            await _planos.Add(plano);
            return new RetornoGenerico<object>
            {
                Success = true,
                Message = "Plano adicionado com sucesso",
                Result = null
            };
        }
        catch(Exception ex)
        {
            return new RetornoGenerico<object>
            {
                Success = false,
                Message = "Não foi possivel adicionar o plano",
                Result = ex
                
            };
        }
    }

    public async Task AtualizarPlanoConvenio(PlanosConvenio plano)
    {
        await _planos.Update(plano);
    }

    public async Task DeletarPlanoConvenio(int idPlanoConvenio)
    {
        PlanosConvenio plano = await ObtemPlanoConvenio(idPlanoConvenio);
        if(plano != null)
            await _planos.Delete(plano);
    }
}
