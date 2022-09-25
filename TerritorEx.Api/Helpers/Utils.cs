using Microsoft.Data.SqlClient;
using TerritorEx.Api.Models.Log;
using TerritorEx.Api.Repository;

namespace TerritorEx.Api.Helpers;

public static class Utils
{
    public static string ConnectionString;

    private static IConfiguration _configuration;

    public static SqlConnection RecuperarConexao()
    {
        try
        {
            return new SqlConnection(ConnectionString);
        }
        catch (Exception exception)
        {
            CriarLogErroArquivo(exception.ToString());
            return null;
        }
    }

    private static string RecuperarParametroAppSettings(string nomeparametro)
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile($"appsettings.json");
        _configuration = builder.Build();

        return _configuration.GetSection(string.Concat("Selenium:", nomeparametro)).Value;
    }

    public static void CriarLogErroDatabase(LogErro erro)
    {
       LogRepository.CriarLogErro(erro);
    }

    private static void CriarLogErroArquivo(string erro)
    {
        var basePath = RecuperarParametroAppSettings("LogErroPath");

        if (!Directory.Exists(basePath))
            if (basePath != null)
                Directory.CreateDirectory(basePath);

        var pathLogs = string.Concat(basePath, "\\log-", DateTime.Now, ".txt");
        var logFileInfo = new FileInfo(pathLogs);

        var fileStream = logFileInfo.Create();
        var streamWriter = new StreamWriter(fileStream);
        streamWriter.WriteLine(erro);
        streamWriter.Close();
    }
}

