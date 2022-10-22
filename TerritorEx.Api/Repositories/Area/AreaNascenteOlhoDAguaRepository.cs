using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Repositories.Area;

public static class AreaNascenteOlhoDAguaRepository
{
    public static IReadOnlyList<AreaNascenteOlhoDAgua> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaNascenteOlhoDAgua>)sqlConnection.GetAll<AreaNascenteOlhoDAgua>();
    }

    public static IReadOnlyList<AreaNascenteOlhoDAgua> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaNascenteOlhoDAgua
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaNascenteOlhoDAgua>)sqlConnection.Query<AreaNascenteOlhoDAgua>(query, new { territorioId });
    }
}