using Microsoft.Data.SqlClient;

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
}

