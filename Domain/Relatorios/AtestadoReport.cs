﻿using Entities.ModelsReports;
using FastReport;
using FastReport.Export.PdfSimple;
using System.Drawing;
using System.Text.Json;

namespace Domain.Relatorios;

public class AtestadoReport
{
    const string reportName = "Atestado.frx";
    public async Task<byte[]> GeneretReport(AtestadoModelReport dados)
    {
        try
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Relatorios\Reprots", reportName);

            using Report report = new Report();

            var logoEmpresa = dados.LogoEmpresa;

            if (logoEmpresa.Contains(","))
            {
                logoEmpresa = logoEmpresa.Split(',')[1];
            }

            while (logoEmpresa.Length % 4 != 0)
            {
                logoEmpresa += "=";
            }

            byte[] imageBytes = Convert.FromBase64String(logoEmpresa);

            Image image = Image.FromStream(new MemoryStream(imageBytes));

            report.Load(path);
            report.SetParameterValue("NomeEmpresa", dados.NomeEmpresa);
            report.SetParameterValue("DataEmissao", dados.DataEmissao);
            report.SetParameterValue("DataInicial", dados.DataInicial);
            report.SetParameterValue("DataFinal", dados.DataFinal);
            report.SetParameterValue("Endereco", dados.Endereco);
            report.SetParameterValue("Bairro", dados.Bairro);
            report.SetParameterValue("Cidade", dados.Cidade);
            report.SetParameterValue("UF", dados.UF.ToString());
            report.SetParameterValue("Descricao", dados.Descricao);
            report.SetParameterValue("NomeFuncionario", dados.NomeFuncionario);
            report.SetParameterValue("NomePaciente", dados.NomePaciente);
            report.SetParameterValue("Telefone", dados.Telefone);
            report.SetParameterValue("CRM", dados.CRM);
            report.SetParameterValue("LogoEmpresa", image);
            await report.PrepareAsync();

            using MemoryStream ms = new MemoryStream();

            using PDFSimpleExport pdf = new PDFSimpleExport();
            pdf.Export(report, ms);

            return ms.ToArray();
        }
        catch (Exception)
        {

            throw;
        }
    }
}
