using Dapper.Contrib.Extensions;

namespace TerritorEx.Api.Helpers.Configuration;

public static class DapperConfiguration
{
    public static void Configure()
    {
        SqlMapperExtensions.TableNameMapper = (type) => type.Name;
    }
}
