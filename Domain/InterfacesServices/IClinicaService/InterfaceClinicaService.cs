using Entities.Models;

namespace Domain.InterfacesServices.IClinicaService;

public interface InterfaceClinicaService
{
    Task AdicionarClinica(Clinica clinica, EnderecoClinica endereco, ContatoClinica contato);
    Task AtualizarClinica(Clinica clinica, EnderecoClinica endereco, ContatoClinica contato);
    Task DeletarClinica(int idClinica);

    #region Endereco
    Task<IList<EnderecoClinica>> ListaEnderecosClinica(int idClinica);
    Task AdicionarEnderecoClinica(EnderecoClinica endereco);
    Task AtualizarEnderecoClinica(EnderecoClinica endereco);
    Task<EnderecoClinica> ObterEnderecoClinica(int idEndereco);
    Task DeletarEnderecoClinica(int idEndereco);
    #endregion
}
