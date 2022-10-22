using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Repositories.Area;

public static class AreaManguezalRepository
{
    public static IReadOnlyList<AreaManguezal> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaManguezal>)sqlConnection.GetAll<AreaManguezal>();
    }

    public static IReadOnlyList<AreaManguezal> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaManguezal
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaManguezal>)sqlConnection.Query<AreaManguezal>(query, new { territorioId });
    }
}