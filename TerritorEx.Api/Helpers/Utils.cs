using Microsoft.Data.SqlClient;
using TerritorEx.Api.Models.Log;
using TerritorEx.Api.Repository;

namespace TerritorEx.Api.Helpers;

public static class Utils
{
    public static string ConnectionString;

    public static SqlConnection GetConnection()
    {
        try
        {
            return new SqlConnection(ConnectionString);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static void CriarLogErro(LogErro erro)
    {
       LogRepository.CriarLogErro(erro);
    }
}

