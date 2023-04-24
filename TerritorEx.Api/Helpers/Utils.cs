using Microsoft.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using TerritorEx.Api.Enums;

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
            CriarLog(TipoLogEnum.Error, exception.ToString(), false);
            return null;
        }
    }

    private static string RecuperarParametroAppSettings(string nomeparametro)
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
        _configuration = builder.Build();

        return _configuration.GetSection(string.Concat(nomeparametro)).Value;
    }

    public static void CriarLog(TipoLogEnum tipoLog, string mensagem, bool enviarEmail)
    {
        var basePath = tipoLog switch
        {
            TipoLogEnum.Error => RecuperarParametroAppSettings("Paths:LogError"),
            TipoLogEnum.Warning => RecuperarParametroAppSettings("Paths:LogWarning"),
            TipoLogEnum.Information => RecuperarParametroAppSettings("Paths:LogInformation"),
            _ => @"C:\TerritorEx\Api\Logs"
        };

        if (!Directory.Exists(basePath))
            Directory.CreateDirectory(basePath!);

        var pathLogs = string.Concat(basePath, "\\", ConverterData(DateTime.Now, "log"), ".txt");
        var logFileInfo = new FileInfo(pathLogs);

        var fileStream = logFileInfo.Create();
        var streamWriter = new StreamWriter(fileStream);
        streamWriter.WriteLine(mensagem);
        streamWriter.Close();

        if (enviarEmail)
            EnviarEMail(mensagem);
    }

    private static void EnviarEMail(string mensagem)
    {
        var smtpEMail = RecuperarParametroAppSettings("Smtp:Email");

        MailMessage mailMessage = new()
        {
            From = new MailAddress(smtpEMail),
            Subject = string.Concat("TerritorEx - Log", ConverterData(DateTime.Now, "pt")),
            IsBodyHtml = true,
            Body = mensagem
        };

        using SmtpClient smtpClient = new(RecuperarParametroAppSettings("Smtp:Host"));

        var credentialPass = RecuperarParametroAppSettings("Smtp:Pass");

        var listaEmail = RecuperarParametroAppSettings("ErrorNotificationEmail");

        foreach (var email in listaEmail
                     .Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            mailMessage.To.Add(email);

        smtpClient.Credentials = new NetworkCredential(smtpEMail, credentialPass);
        smtpClient.Port = Convert.ToInt32(RecuperarParametroAppSettings("Smtp:Port"));
        smtpClient.EnableSsl = true;

        try
        {
            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    private static string ConverterData(DateTime dataHora, string padrao)
    {
        return padrao switch
        {
            "en" => dataHora.ToString("mm/dd/yyyy HH:mm:ss"),
            "pt" => dataHora.ToString("dd/MM/yyyy HH:mm:ss"),
            "log" => dataHora.ToString("ddMMyyyyHHmmss"),
            _ => dataHora.ToString("mm/dd/yyyy HH:mm:ss"),
        };
    }
}

