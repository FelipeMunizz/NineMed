using Domain.Interfaces.ISenhaToten;
using Domain.InterfacesServices;
using Enities.Enums;
using Enities.Models;
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
            SenhaToten ultimaSenhaMesmoAtendimento = await _repository.UltimaSenhaTotenTipoAtendimento(obj.TipoAtendimento);

            string senhaPainel = string.Empty;

            if (ultimaSenhaMesmoAtendimento != null)
            {
                senhaPainel = obj.TipoAtendimento == TipoAtendimento.Prioritario ? $"PR0{ultimaSenhaMesmoAtendimento.Id + 1}"
                    : $"CM0{ultimaSenhaMesmoAtendimento.Id + 1}";
            }
            else
            {
                senhaPainel = obj.TipoAtendimento == TipoAtendimento.Prioritario ? "PR00" : "CM00";
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

    public Task AtualizarSenhaToten(SenhaToten obj)
    {
        throw new NotImplementedException();
    }

    public Task DeletarSenhasTotenDiarias(DateTime diaAtual)
    {
        throw new NotImplementedException();
    }
}
