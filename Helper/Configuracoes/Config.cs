namespace Helper.Configuracoes;

public static class Config
{
    private const Ambiente ambiente = Ambiente.PCFelipe;

    public static string DiretorioLogs = DiretorioLog();

    public static string ConectionString = StringsConnection(ambiente);

    private static string DiretorioLog()
    {
        string pastaLogs = "LogsGerados";
        string diretorioBin = AppDomain.CurrentDomain.BaseDirectory;
        string caminhoPastaLogs = Path.Combine(diretorioBin, pastaLogs);

        if (!Directory.Exists(caminhoPastaLogs))
        {
            Directory.CreateDirectory(caminhoPastaLogs);
        }

        return caminhoPastaLogs;
    }

    private static string StringsConnection(Ambiente ambientes)
    {
        switch (ambientes)
        {
            case Ambiente.PCFelipe:
                return "Data Source=DESKTOP-HER7P6R;Initial Catalog=NineMed;Integrated Security=True;Pooling=False;Encrypt=False;TrustServerCertificate=False;";
            case Ambiente.NotFelipe:
                return "Data Source=DESKTOP-HH8094V;Initial Catalog=NineMed;Integrated Security=True;Pooling=False;Encrypt=False;TrustServerCertificate=False;";
            case Ambiente.Producao:
                return string.Empty;
            default: return string.Empty;

        }
    }
}

public enum Ambiente
{
    PCFelipe,
    NotFelipe,
    Producao
}