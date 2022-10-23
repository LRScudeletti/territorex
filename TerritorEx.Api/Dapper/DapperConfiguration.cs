using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Dapper;

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
