using Microsoft.Data.SqlClient;

namespace TerritorEx.Api.Helpers;

public static class Utils
{
    private static IConfiguration _configuration;

    public static SqlConnection RecuperarConexao()
    {
        try
        {
            return new SqlConnection(Connection.ConnectionString);
        }
        catch (Exception exception)
        {
            CriarLogErro(exception.ToString());
            return null;
        }
    }

    private static string RecuperarParametroAppSettings(string nomeparametro)
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile($"appsettings.json");
        _configuration = builder.Build();

        return _configuration.GetSection(string.Concat(nomeparametro)).Value;
    }

    public static void CriarLogErro(string erro)
    {
        var basePath = RecuperarParametroAppSettings("Paths:ErroPath");

        if (!Directory.Exists(basePath))
            if (basePath != null)
                Directory.CreateDirectory(basePath);

        var pathLogs = string.Concat(basePath, "\\log-", ConverterData(DateTime.Now, "log"), ".txt");
        var logFileInfo = new FileInfo(pathLogs);

        var fileStream = logFileInfo.Create();
        var streamWriter = new StreamWriter(fileStream);
        streamWriter.WriteLine(erro);
        streamWriter.Close();
    }

    private static string ConverterData(DateTime dataHora, string padrao)
    {
        return padrao switch
        {
            "pt-BR" => dataHora.ToString("dd/MM/yyyy HH:mm:ss"),
            "log" => dataHora.ToString("dd-MM-yyyy HH-mm-ss"),
            _ => dataHora.ToString("dd/MM/yyyy HH:mm:ss"),
        };
    }
}

