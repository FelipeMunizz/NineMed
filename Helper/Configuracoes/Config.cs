namespace Helper.Configuracoes;

public static class Config
{
    private const Ambiente ambiente = Ambiente.Producao;

    public static string ConectionString = StringsConnection(ambiente);
    public const string SecurityKey = "43443FDFDF34DF34343fdf344SDFSDFSDFSDFSDF4545354345SDFGDFGDFGDFGdffgfdGDFGDGR%";

    private static string StringsConnection(Ambiente ambientes)
    {
        switch (ambientes)
        {
            case Ambiente.PCFelipe:
                return "Data Source=DESKTOP-HER7P6R;Initial Catalog=NineMed;Integrated Security=True;Pooling=False;Encrypt=False;TrustServerCertificate=False;";
            case Ambiente.NotFelipe:
                return "Data Source=DESKTOP-HH8094V;Initial Catalog=NineMed;Integrated Security=True;Pooling=False;Encrypt=False;TrustServerCertificate=False;";
            case Ambiente.Producao:
                return "workstation id=ninemed.mssql.somee.com;packet size=4096;user id=FeMuniz_SQLLogin_1;pwd=pqj5if9kcd;data source=ninemed.mssql.somee.com;persist security info=False;initial catalog=ninemed;TrustServerCertificate=True";
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