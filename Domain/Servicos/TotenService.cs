using Domain.Interfaces.IToten;
using Domain.InterfacesServices.ITotenService;
using Entities.Enums;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class TotenService : InterfaceTotenService
{
    private readonly InterfaceSenhaToten _repositorySenhas;
    private readonly InterfaceToten _repositoryToten;

    public TotenService(InterfaceSenhaToten repositorySenhas, InterfaceToten repositoryToten)
    {
        _repositorySenhas = repositorySenhas;
        _repositoryToten = repositoryToten;
    }

    #region Toten
    public async Task AdicionarToten(Toten toten)
    {
        await _repositoryToten.Add(toten);
    }

    public async Task AtualizarToten(Toten toten)
    {
        await _repositoryToten.Update(toten);
    }

    public async Task DeletarToten(int idToten)
    {
        Toten toten = await _repositoryToten.GetEntityById(idToten);
        if (toten != null)
            await _repositoryToten.Delete(toten);
    }
    #endregion

    #region SenhasToten
    public async Task<IList<SenhaToten>> ListaSenhasPainel(int idToten) => await _repositorySenhas.ListaSenhasPainel(idToten);

    public async Task<IList<SenhaToten>> ListaSenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento, int idToten)
        => await _repositorySenhas.ListaSenhaTotenTipoAtendimento(tipoAtendimento, idToten);

    public async Task<RetornoGenerico<SenhaToten>> AdicionarSenhaToten(SenhaToten obj)
    {
        try
        {
            int ultimaSenhaMesmoAtendimento = await _repositorySenhas.SenhaTotenTipoAtendimento(obj.TipoAtendimento, obj.IdToten);

            string senhaPainel = string.Empty;

            if (ultimaSenhaMesmoAtendimento > 0)
            {
                switch (obj.TipoAtendimento)
                {
                    case TipoAtendimento.Prioritario:
                        senhaPainel = $"P0{ultimaSenhaMesmoAtendimento + 1}";
                        break;
                    case TipoAtendimento.PrioritarioAgendado:
                        senhaPainel = $"PA0{ultimaSenhaMesmoAtendimento + 1}";
                        break;
                    case TipoAtendimento.Comum:
                        senhaPainel = $"C0{ultimaSenhaMesmoAtendimento + 1}";
                        break;
                    case TipoAtendimento.ComumAgendado:
                        senhaPainel = $"CA0{ultimaSenhaMesmoAtendimento + 1}";
                        break;
                }
            }
            else
            {
                switch (obj.TipoAtendimento)
                {
                    case TipoAtendimento.Prioritario:
                        senhaPainel = $"P01";
                        break;
                    case TipoAtendimento.PrioritarioAgendado:
                        senhaPainel = $"PA01";
                        break;
                    case TipoAtendimento.Comum:
                        senhaPainel = $"C01";
                        break;
                    case TipoAtendimento.ComumAgendado:
                        senhaPainel = $"CA01";
                        break;
                }
            }

            SenhaToten novaSenha = new SenhaToten
            {
                SenhaPainel = senhaPainel,
                TipoAtendimento = obj.TipoAtendimento,
                StatusAtendimento = StatusAtendimento.Chegada,
                DataHoraCriacao = DateTime.Now,
                DataHoraAtualizacao = DateTime.Now,
                IdToten = obj.IdToten
            };

            novaSenha = await _repositorySenhas.Add(novaSenha);

            if (novaSenha.Id.Equals(0))
                return new RetornoGenerico<SenhaToten>
                {
                    Success = false,
                    Message = "Não foi possivel gerar a senha"
                };


            return new RetornoGenerico<SenhaToten>
            {
                Success = true,
                Message = "Senha gerada com sucesso",
                Result = novaSenha
            };

        }
        catch (Exception ex)
        {
            return new RetornoGenerico<SenhaToten>
            {
                Success = false,
                Message = ex.Message,
            };
        }
    }

    public async Task AtualizarSenhaToten(SenhaToten obj)
    {
        try
        {
            SenhaToten senha = await _repositorySenhas.ObtemSenhaPainel(obj.SenhaPainel, obj.IdToten);

            senha.StatusAtendimento = obj.StatusAtendimento;
            senha.DataHoraAtualizacao = DateTime.Now;

            await _repositorySenhas.Update(senha);
        }
        catch (Exception ex)
        {
            return;
        }
    }

    public async Task DeletarSenhasTotenDiarias(int idToten)
    {
        try
        {
            IList<SenhaToten> senhasParaExcluir = await _repositorySenhas.SenhasParaExcluir(DateTime.Now, idToten);

            foreach (var senhaToten in senhasParaExcluir)
                await _repositorySenhas.Delete(senhaToten);
        }
        catch (Exception ex)
        {
            return;
        }
    }
    #endregion
}
