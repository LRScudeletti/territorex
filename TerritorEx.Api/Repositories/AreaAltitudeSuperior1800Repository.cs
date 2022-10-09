using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Repositories;

public static class AreaAltitudeSuperior1800Repository
{
    public static IEnumerable<AreaAltitudeSuperior1800> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return sqlConnection.GetAll<AreaAltitudeSuperior1800>();
    }
}