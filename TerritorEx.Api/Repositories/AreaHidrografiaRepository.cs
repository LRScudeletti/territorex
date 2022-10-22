using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Repositories;

public static class AreaHidrografiaRepository
{
    public static IReadOnlyList<AreaHidrografia> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaHidrografia>)sqlConnection.GetAll<AreaHidrografia>();
    }

    public static IReadOnlyList<AreaHidrografia> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaHidrografia
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaHidrografia>)sqlConnection.Query<AreaHidrografia>(query, new { territorioId });
    }
}