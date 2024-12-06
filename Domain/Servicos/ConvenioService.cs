using Domain.Interfaces.IConvenio;
using Domain.Interfaces.IFuncionario;
using Domain.InterfacesServices.IConvenioService;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class ConvenioService : InterfaceConvenioService
{
    private readonly InterfaceConvenio _convenio;
    private readonly InterfacePlanosConvenio _planos;
    private readonly InterfaceProfissionalSaudeConvenio _profissionalSaude;
    private readonly InterfaceFuncionario _funcioanrio;

    public ConvenioService(InterfaceConvenio convenio, InterfacePlanosConvenio planos, InterfaceProfissionalSaudeConvenio profissionalSaude, InterfaceFuncionario funcioanrio)
    {
        _convenio = convenio;
        _planos = planos;
        _profissionalSaude = profissionalSaude;
        _funcioanrio = funcioanrio;
    }

    public async Task<RetornoGenerico<Convenio>> AdicionarConvenio(Convenio convenio)
    {
        convenio = await _convenio.Add(convenio);
        if (convenio.Id > 0)
            return new RetornoGenerico<Convenio>
            {
                Success = true,
                Message = "Convenio adicionado com sucesso.",
                Result = convenio
            };
        else
            return new RetornoGenerico<Convenio>
            {
                Success = false,
                Message = "Erro ao adicionar o convenio."
            };

    }

    public async Task AtualizarConvenio(Convenio convenio)
    {
        await _convenio.Update(convenio);
    }

    public async Task DeletarConvenio(int idConvenio)
    {
        Convenio convenio = await _convenio.GetEntityById(idConvenio);
        if (convenio != null)
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
        catch (Exception ex)
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
        if (plano != null)
            await _planos.Delete(plano);
    }

    public async Task<IList<ProfissionaisSaudeConvenio>> ListaProfissionaisSaudeConvenio(int idConvenio) =>
        await _profissionalSaude.ListaProfissionaisConvenio(idConvenio);

    public async Task<ProfissionaisSaudeConvenio> ObtemProfissionalSaudeConvenio(int idProfissional) =>
        await _profissionalSaude.GetEntityById(idProfissional);

    public async Task<RetornoGenerico<object>> AdicionarProfissionalSaudeConvenio(ProfissionaisSaudeConvenio profissionaisSaude)
    {
        try
        {
            Funcionario funcionario = await _funcioanrio.GetEntityById(profissionaisSaude.IdFuncionario);
            if (funcionario.ProfissionalSaude)
            {
                if (!await _profissionalSaude.ProfissionalAtendeConvenio(funcionario.Id, profissionaisSaude.IdConvenio))
                    await _profissionalSaude.Add(profissionaisSaude);
                else
                    return new RetornoGenerico<object>
                    {
                        Success = true,
                        Message = "Profissional já atende o convênio"
                    };
            }
            else
                return new RetornoGenerico<object>
                {
                    Success = false,
                    Message = "Funcionário não é profissional da saúde"
                };

            return new RetornoGenerico<object>
            {
                Success = true,
                Message = "Profissional da saúde cadastrado ao convenio com sucesso"
            };

        }
        catch (Exception ex)
        {
            return new RetornoGenerico<object> { Success = false, Result = ex, Message = "Não foi possivel cadastrar o funcionario ao convenio" };
        }
    }

    public async Task AtualizarProfissionalSaudeConvenio(ProfissionaisSaudeConvenio plano)
    {
        await _profissionalSaude.Update(plano);
    }

    public async Task DeletarProfissionalSaudeConvenio(int idPlanoConvenio)
    {
        ProfissionaisSaudeConvenio profissionalSaude = await ObtemProfissionalSaudeConvenio(idPlanoConvenio);
        if (profissionalSaude != null)
            await _profissionalSaude.Delete(profissionalSaude);
    }

    public async Task<bool> ProfissionalAtendeConvenio(int idFuncionario, int idConvenio) =>
        await _profissionalSaude.ProfissionalAtendeConvenio(idFuncionario, idConvenio);
}
