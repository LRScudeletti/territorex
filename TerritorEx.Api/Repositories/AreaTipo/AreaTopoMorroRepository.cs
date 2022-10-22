using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Repositories.Area;

public static class AreaTopoMorroRepository
{
    public static IReadOnlyList<AreaTopoMorro> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaTopoMorro>)sqlConnection.GetAll<AreaTopoMorro>();
    }

    public static IReadOnlyList<AreaTopoMorro> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaTopoMorro
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaTopoMorro>)sqlConnection.Query<AreaTopoMorro>(query, new { territorioId });
    }
}