using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Repositories;

public static class AreaUsoRestritoRepository
{
    public static IReadOnlyList<AreaUsoRestrito> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaUsoRestrito>)sqlConnection.GetAll<AreaUsoRestrito>();
    }

    public static IReadOnlyList<AreaUsoRestrito> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaUsoRestrito
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaUsoRestrito>)sqlConnection.Query<AreaUsoRestrito>(query, new { territorioId });
    }
}