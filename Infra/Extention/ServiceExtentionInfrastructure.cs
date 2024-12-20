using Domain.Interfaces.Generics;
using Domain.Interfaces.IAgendamento;
using Domain.Interfaces.IAtendimento;
using Domain.Interfaces.IBanco;
using Domain.Interfaces.ICategoriaFinanceira;
using Domain.Interfaces.ICentroCusto;
using Domain.Interfaces.IClinica;
using Domain.Interfaces.IConfiguracaoClinica;
using Domain.Interfaces.IConfiguracaoFinanceira;
using Domain.Interfaces.IContaBancaria;
using Domain.Interfaces.IConvenio;
using Domain.Interfaces.IFormaPagamento;
using Domain.Interfaces.IFuncionario;
using Domain.Interfaces.ILancamento;
using Domain.Interfaces.IPaciente;
using Domain.Interfaces.IProcedimento;
using Domain.Interfaces.ISubCategoria;
using Domain.Interfaces.IToten;
using Infra.Repositorio.AgendamentoRepositorio;
using Infra.Repositorio.AtendimentoRepositorio;
using Infra.Repositorio.BancoRepositorio;
using Infra.Repositorio.CategoriaFinanceiraRepository;
using Infra.Repositorio.CentroCustoRepositorio;
using Infra.Repositorio.ClinicaRepositorio;
using Infra.Repositorio.ConfiguracaoClinicaRepositorio;
using Infra.Repositorio.ConfiguracaoFinanceiraRepositorio;
using Infra.Repositorio.ContaBancariaRepositorio;
using Infra.Repositorio.ConvenioRepositorio;
using Infra.Repositorio.FormaPagamentoRepositorio;
using Infra.Repositorio.FuncionarioRepositorio;
using Infra.Repositorio.Generico;
using Infra.Repositorio.LancamentoRepositorio;
using Infra.Repositorio.PacienteRepositorio;
using Infra.Repositorio.ProcedimentoRepositorio;
using Infra.Repositorio.SubCategoriaRepositorio;
using Infra.Repositorio.TotenRepositorio;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Extention
{
    public static class ServiceExtentionInfrastructure
    {
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services)
        {
            #region Repositorios
            services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositorioGenerico<>));
            services.AddScoped<InterfaceToten, TotenRepository>();
            services.AddScoped<InterfaceSenhaToten, SenhaTotenRepository>();

            #region Convenio
            services.AddScoped<InterfaceConvenio, ConvenioRepository>();
            services.AddScoped<InterfacePlanosConvenio, PlanosConvenioRepository>();
            services.AddScoped<InterfaceProfissionalSaudeConvenio, ProfissionalSaudeConvenioRepository>();
            #endregion

            #region Clinica
            services.AddScoped<InterfaceClinica, ClinicaRepository>();
            services.AddScoped<InterfaceContatoClinica, ContatoClinicaRepository>();
            services.AddScoped<InterfaceEnderecoClinica, EnderecoClinicaRepository>();
            #endregion

            #region Paciente
            services.AddScoped<InterfacePaciente, PacienteRepository>();
            services.AddScoped<InterfacePacienteContato, PacienteContatoRepository>();
            services.AddScoped<InterfacePacienteConvenio, PacienteConvenioRepository>();
            services.AddScoped<InterfacePacienteEndereco, PacienteEnderecoRepository>();
            services.AddScoped<InterfacePacienteFamiliar, PacienteFamiliarRepoistory>();
            services.AddScoped<InterfacePacienteProntuario, PacienteProntuarioRepository>();
            #endregion

            #region Agendamento
            services.AddScoped<InterfaceAgendamento, AgendamentoRepository>();
            #endregion

            #region Atendimento
            services.AddScoped<InterfaceAtendimento, AtendimentoRepository>();
            services.AddScoped<InterfaceExameAtendimento, ExamesAtendimentoRepository>();
            services.AddScoped<InterfacePrescricaoAtendimento, PrescricaoAtendimentoRepository>();
            services.AddScoped<InterfaceAnexosAtendimento, AnexosAtendimentoRepository>();
            services.AddScoped<InterfaceAtestadoAtendimento, AtestadoAtendimentoRepository>();
            #endregion

            services.AddScoped<InterfaceFuncionario, FuncionarioRepository>();
            services.AddScoped<InterfaceHorarioFuncionario, HorarioFuncionarioRepository>();
            services.AddScoped<InterfaceProcedimento, ProcedimentoRepository>();
            services.AddScoped<InterfaceConfiguracaoClinica, ConfiguracaoClinicaRepository>();
            services.AddScoped<IBanco, BancoRepository>();
            services.AddScoped<InterfaceContaBancaria, ContaBancariaRepository>();
            services.AddScoped<InterfaceSubCategoria, SubCategoriaRepository>();
            services.AddScoped<InterfaceCentroCusto, CentroCustoRepository>();
            services.AddScoped<InterfaceConfiguracaoFinanceira, ConfiguracaoFinanceiraRepository>();
            services.AddScoped<InterfaceLancamento, LancamentoRepository>();
            services.AddScoped<InterfaceCategoriaFinanceira, CategoriaFinanceiraRepository>();
            services.AddScoped<InterfaceFormaPagamento, FormaPagamentoRepository>();
            #endregion

            return services;
        }
    }
}
