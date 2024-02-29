using Domain.Interfaces.IBanco;
using Domain.InterfacesServices.IBancoService;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class BancoService : InterfaceBancoService
{
    private readonly IBanco _repository;

    public BancoService(IBanco repository)
    {
        _repository = repository;
    }

    public async Task<RetornoGenerico<Banco>> AdicionarBanco(Banco banco)
    {
        banco = await _repository.Add(banco);

        if (banco.Id == 0)
            return new RetornoGenerico<Banco>
            {
                Success = false,
                Message = "Não foi possível adicionar o banco"
            };
        else
            return new RetornoGenerico<Banco>
            {
                Success = true,
                Message = "Banco adicionado com sucesso",
                Result = banco
            };
    }

    public async Task AtualizarBanco(Banco banco)
    {
        await _repository.Update(banco);
    }

    public async Task<RetornoGenerico<object>> DeletarBanco(int idBanco)
    {
        Banco banco = await _repository.GetEntityById(idBanco);
        if (banco == null)
            return new RetornoGenerico<object>
            {
                Success = false,
                Message = "Não foi possível localizar o banco"
            };

        await _repository.Delete(banco);

        return new RetornoGenerico<object> { Success = true, Message = "Banco Deletado com sucesso" };
    }

    public async Task<IList<Banco>> ListarBancosClinica(int idClinica)
    {
        return await _repository.ListaBancosClinica(idClinica);
    }

    public async Task<Banco> ObterBanco(int idBanco)
    {
        return await _repository.GetEntityById(idBanco);
    }
}
