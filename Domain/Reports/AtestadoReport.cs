using Domain.InterfacesServices.IAtendimentoService;
using Entities.ModelsReports;
using Microsoft.Reporting.NETCore;
using System.Collections;

namespace Domain.Reports;

public class AtestadoReport
{
    private readonly InterfaceAtendimentoService _atendimentoService;
    private readonly string ReportName = "AtestadoReport";

    public AtestadoReport(InterfaceAtendimentoService atendimentoService)
    {
        _atendimentoService = atendimentoService;
    }

    public async Task<string> GetAtestadoReport(int idAtendimento)
    {
        string pathReport = Path.Combine(AppContext.BaseDirectory, "Domain", "Reports", "rdlc", ReportName);

        if (File.Exists(pathReport))
        {
            throw new FileNotFoundException(pathReport);
        }

        AtestadoModelReport atestado = await _atendimentoService.ObterAtestadoRelatorio(idAtendimento);
        Stream reportDefinition;
        IEnumerable dataSource = new List<AtestadoModelReport> { atestado };

        LocalReport report = new LocalReport
        {
            ReportPath = pathReport
        };

        report.DataSources.Add(new ReportDataSource("AtestadoDataSet", dataSource));
        string mimeType, encoding, fileNameExtension;
        Warning[] warnings;
        string[] streams;

        byte[] reportBytes = report.Render(
        "PDF",
        null,
        out mimeType,
        out encoding,
        out fileNameExtension,
        out streams,
        out warnings);

        string reportBase64 = Convert.ToBase64String(reportBytes);

        return reportBase64;
    }
}
