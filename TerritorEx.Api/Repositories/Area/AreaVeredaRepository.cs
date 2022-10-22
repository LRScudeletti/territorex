using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Repositories.Area;

public static class AreaVeredaRepository
{
    public static IReadOnlyList<AreaVereda> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaVereda>)sqlConnection.GetAll<AreaVereda>();
    }

    public static IReadOnlyList<AreaVereda> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaVereda
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaVereda>)sqlConnection.Query<AreaVereda>(query, new { territorioId });
    }
}