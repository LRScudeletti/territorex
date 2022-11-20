using Dapper.Contrib.Extensions;

namespace TerritorEx.Api.Helpers.Configuration;

public static class DapperConfiguration
{
    public static void ConnectionString(WebApplicationBuilder builder)
    {
        Connection.ConnectionString = builder.Configuration.GetConnectionString("ApiDatabase");

        // Essa linha altera a característica do Dapper 
        // de colocar 's' no nome das entidades mapeadas
        SqlMapperExtensions.TableNameMapper = (type) => type.Name;
    }
}
