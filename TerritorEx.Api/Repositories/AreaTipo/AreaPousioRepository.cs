using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Repositories.Area;

public static class AreaPousioRepository
{
    public static IReadOnlyList<AreaPousio> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaPousio>)sqlConnection.GetAll<AreaPousio>();
    }

    public static IReadOnlyList<AreaPousio> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaPousio
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaPousio>)sqlConnection.Query<AreaPousio>(query, new { territorioId });
    }
}