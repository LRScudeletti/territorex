namespace TerritorEx.Api.Helpers;

internal static class Connection
{
    public static string ConnectionString;

    public static void AddConnectionString(WebApplicationBuilder builder)
    {
        ConnectionString = builder.Configuration.GetConnectionString("ApiDatabase");
    }
}