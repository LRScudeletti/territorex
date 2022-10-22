using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Repositories;

public static class AreaDeclividadeMaior45Repository
{
    public static IReadOnlyList<AreaDeclividadeMaior45> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaDeclividadeMaior45>)sqlConnection.GetAll<AreaDeclividadeMaior45>();
    }

    public static IReadOnlyList<AreaDeclividadeMaior45> RecuperarPorTerritorioId(int territorioId)
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

        return (IReadOnlyList<AreaDeclividadeMaior45>)sqlConnection.Query<AreaDeclividadeMaior45>(query, new { territorioId });
    }
}