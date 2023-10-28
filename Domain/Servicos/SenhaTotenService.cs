using Domain.Interfaces.ISenhaToten;
using Domain.InterfacesServices;
using Entities.Enums;
using Entities.Models;
using Helper.Logs;

namespace Domain.Servicos;

public class SenhaTotenService : InterfaceSenhaTotenService
{
    private readonly InterfaceSenhaToten _repository;

    public SenhaTotenService(InterfaceSenhaToten repository)
    {
        _repository = repository;
    }

    public async Task AdicionarSenhaToten(SenhaToten obj)
    {
        try
        {
            int ultimaSenhaMesmoAtendimento = await _repository.SenhaTotenTipoAtendimento(obj.TipoAtendimento);

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
                DataHoraAtualizacao = DateTime.Now
            };

            await _repository.Add(novaSenha);

        }
        catch (Exception ex)
        {
            LogProxy.GravarLogException(ex);
        }
    }

    public async Task AtualizarSenhaToten(SenhaToten obj)
    {
        try
        {
            SenhaToten senha = await _repository.ObtemSenhaPainel(obj.SenhaPainel);

            senha.StatusAtendimento = obj.StatusAtendimento;
            senha.DataHoraAtualizacao = DateTime.Now;

            await _repository.Update(senha);
        }
        catch (Exception ex)
        {
            LogProxy.GravarLogException(ex);
        }
    }

    public async Task DeletarSenhasTotenDiarias()
    {
        try
        {
            IList<SenhaToten> senhasParaExcluir = await _repository.SenhasParaExcluir(DateTime.Now);

            foreach (var senhaToten in senhasParaExcluir)
                await _repository.Delete(senhaToten);
        }
        catch (Exception ex)
        {
            LogProxy.GravarLogException(ex);
        }
    }
}
