using System.Text;

namespace Helper.Logs
{
    internal class LogProxy
    {
        public static void GravarLogException(Exception exception)
        {
            var sb = new StringBuilder();

            var current = exception;
            while (current != null)
            {
                if (current != exception) sb.AppendLine("Inner exception:");
                else sb.AppendLine($"Exception occurred at {DateTime.Now:dd/MM/yyyy HH:mm:ss}:");

                sb.AppendLine(exception.Message);

                sb.AppendLine();
                sb.AppendLine("Stack Trace:");
                sb.AppendLine(exception.StackTrace);

                sb.AppendLine();
                sb.AppendLine("Source:");
                sb.AppendLine(exception.Source);

                sb.AppendLine();
                sb.AppendLine();

                current = current.InnerException;
            }

            GravarLog(sb.ToString(), $"{DateTime.Now:yyyy-MM-dd___HH_mm_ss}_ExceptionLog");
        }

        public static void GravarLogErro(string descricao, string mensagemErro, string nomeArquivo = "LogGenerico")
        {
            try
            {
                GravarLog($"|| {descricao}", nomeArquivo);
                GravarLog($"|>>>>>>> {mensagemErro}", nomeArquivo);
            }
            catch { }
        }

        public static void GravarLog(string mensagem, string nomeArquivo = "LogGenerico")
        {
            try
            {
                //Directory.CreateDirectory(Configuracao.DIRETORIO_LOGS);

                //var diretorio = $@"{Configuracao.DIRETORIO_LOGS}\{nomeArquivo}.txt";

                //using (var w = File.AppendText(diretorio))
                //{
                //    w.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                //    w.WriteLine($"{mensagem}");
                //    w.Close();
                //}
            }
            catch { }
        }
    }
}
