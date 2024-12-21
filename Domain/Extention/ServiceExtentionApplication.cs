using Domain.InterfacesServices.IAgendamentoService;
using Domain.InterfacesServices.IAtendimentoService;
using Domain.InterfacesServices.IBancoService;
using Domain.InterfacesServices.ICategoriaFinanceiraService;
using Domain.InterfacesServices.ICentroCustoService;
using Domain.InterfacesServices.IClinicaService;
using Domain.InterfacesServices.IConfiguracaoClinicaService;
using Domain.InterfacesServices.IConfiguracaoFinanceiraService;
using Domain.InterfacesServices.IContaBancariaService;
using Domain.InterfacesServices.IConvenioService;
using Domain.InterfacesServices.IFormaPagamentoService;
using Domain.InterfacesServices.IFuncionarioService;
using Domain.InterfacesServices.ILancamentoService;
using Domain.InterfacesServices.IPacienteService;
using Domain.InterfacesServices.IProcedimentoService;
using Domain.InterfacesServices.ISubCategoriaService;
using Domain.InterfacesServices.ITotenService;
using Domain.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extention
{
    public static class ServiceExtentionApplication
    {
        public static IServiceCollection AddSharedApplication(this IServiceCollection services)
        {
            #region Servicos
            services.AddScoped<InterfaceTotenService, TotenService>();
            services.AddScoped<InterfaceClinicaService, ClinicaService>();
            services.AddScoped<InterfaceConvenioService, ConvenioService>();
            services.AddScoped<InterfaceFuncionarioService, FuncionarioService>();
            services.AddScoped<InterfaceProcedimentoService, ProcedimentoService>();
            services.AddScoped<InterfacePacienteService, PacienteService>();
            services.AddScoped<InterfaceConfiguracaoClinicaService, ConfiguracaoClinicaService>();
            services.AddScoped<InterfaceAgendamentoService, AgendamentoService>();
            services.AddScoped<InterfaceAtendimentoService, AtendimentoService>();
            services.AddScoped<InterfaceBancoService, BancoService>();
            services.AddScoped<InterfaceContaBancariaService, ContaBancariaService>();
            services.AddScoped<InterfaceSubCategoriaService, SubCategoriaService>();
            services.AddScoped<InterfaceCentroCustoService, CentroCustoService>();
            services.AddScoped<InterfaceConfiguracaoFinanceiraService, ConfiguracaoFinanceiraService>();
            services.AddScoped<InterfaceLancamentoService, LancamentoService>();
            services.AddScoped<InterfaceCategoriaFinanceiraService, CategoriaFinanceiraService>();
            services.AddScoped<InterfaceFormaPagamentoService, FormaPagamentoService>();
            #endregion

            return services;
        }
    }
}
