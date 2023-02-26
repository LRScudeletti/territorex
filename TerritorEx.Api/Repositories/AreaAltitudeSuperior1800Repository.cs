using Dapper;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Repositories;

public static class AreaAltitudeSuperior1800Repository
{
    public static IReadOnlyList<Area> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaAltitudeSuperior1800;";

        return (IReadOnlyList<Area>)sqlConnection.Query<Area>(sql);
    }

    public static IReadOnlyList<Area> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaAltitudeSuperior1800
                              WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<Area>)sqlConnection.Query<Area>(sql, new { territorioId });
    }
}