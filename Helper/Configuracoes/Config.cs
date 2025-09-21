namespace Helper.Configuracoes;

public static class Config
{
    private const Ambiente ambiente = Ambiente.NotFelipe;

    public static string ConectionString = StringsConnection(ambiente);
    public static string ConnectionStringRedis = "redis-10324.c308.sa-east-1-1.ec2.redns.redis-cloud.com:10324,password=FTj4ec3M8kV8p2RNRAxXLRKejsh3MTu5";
    public const string SecurityKey = "43443FDFDF34DF34343fdf344SDFSDFSDFSDFSDF4545354345SDFGDFGDFGDFGdffgfdGDFGDGR%";
    public const string ApiKeyFileIO = "FR2RIWQ.WF3PS58-WCR4M5X-K32FV35-NY36A91";

    private static string StringsConnection(Ambiente ambientes)
    {
        switch (ambientes)
        {
            case Ambiente.NotFelipe:
                return "Data Source=DESKTOP-RVJ8D0O\\SQLEXPRESS;Initial Catalog=NineMed;Integrated Security=True;Pooling=False;Encrypt=False;TrustServerCertificate=False;";
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