using Entities.Models;

namespace Domain.InterfacesServices;

public interface InterfaceClinicaService
{
    Task AdicionarClinica(Clinica clinica, EnderecoClinica endereco, ContatoClinica contato);
    Task AtualizarClinica(Clinica clinica, EnderecoClinica endereco, ContatoClinica contato);
    Task DeletarClinica(int idClinica);
}
