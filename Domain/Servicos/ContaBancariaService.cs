using Domain.Interfaces.IContaBancaria;
using Domain.InterfacesServices.IContaBancariaService;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class ContaBancariaService : InterfaceContaBancariaService
{
    private readonly InterfaceContaBancaria _repository;

    public ContaBancariaService(InterfaceContaBancaria repository)
    {
        _repository = repository;
    }

    public async Task<RetornoGenerico<ContaBancaria>> AdicionarContaBancaria(ContaBancaria ContaBancaria)
    {
        ContaBancaria = await _repository.Add(ContaBancaria);

        if (ContaBancaria.Id == 0)
            return new RetornoGenerico<ContaBancaria>
            {
                Success = false,
                Message = "Não foi possível adicionar o Conta Bancaria"
            };
        else
            return new RetornoGenerico<ContaBancaria>
            {
                Success = true,
                Message = "Conta Bancaria adicionado com sucesso",
                Result = ContaBancaria
            };
    }

    public async Task AtualizarContaBancaria(ContaBancaria ContaBancaria)
    {
        await _repository.Update(ContaBancaria);
    }

    public async Task<RetornoGenerico<object>> DeletarContaBancaria(int idContaBancaria)
    {
        ContaBancaria ContaBancaria = await _repository.GetEntityById(idContaBancaria);
        if (ContaBancaria == null)
            return new RetornoGenerico<object>
            {
                Success = false,
                Message = "Não foi possível localizar o Conta Bancaria"
            };

        await _repository.Delete(ContaBancaria);

        return new RetornoGenerico<object> { Success = true, Message = "Conta Bancaria Deletado com sucesso" };
    }

    public async Task<IList<ContaBancaria>> ListaContasBancariaBanco(int idClinica)
    {
        return await _repository.ListaContasBancariaBanco(idClinica);
    }

    public async Task<ContaBancaria> ObterContaBancaria(int idContaBancaria)
    {
        return await _repository.GetEntityById(idContaBancaria);
    }
}
