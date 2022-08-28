using Microsoft.Data.SqlClient;

namespace TerritorEx.Api.Helpers;

public class SqlHelper
{
    public static string ConnectionString;

    public static SqlConnection GetConnection()
    {
        try
        {
            return new SqlConnection(ConnectionString);
        }
        catch (Exception exception)
        {
            Console.WriteLine(string.Concat(
                Properties.Resources.CouldNotConnectToSatabase), Environment.NewLine, exception);
            throw;
        }
    }
}

