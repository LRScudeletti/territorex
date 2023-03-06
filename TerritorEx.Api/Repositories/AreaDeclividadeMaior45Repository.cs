using Dapper;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Repositories;

public static class AreaDeclividadeMaior45Repository
{
    public static IReadOnlyList<Area> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaDeclividadeMaior45;";

        return (IReadOnlyList<Area>)sqlConnection.Query<Area>(query);
    }

    public static IReadOnlyList<Area> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaDeclividadeMaior45
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<Area>)sqlConnection.Query<Area>(query, new { territorioId });
    }
}