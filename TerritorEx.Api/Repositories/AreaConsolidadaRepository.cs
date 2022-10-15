using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Repositories;

public static class AreaConsolidadaRepository
{
    public static IReadOnlyList<AreaConsolidada> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaConsolidada>)sqlConnection.GetAll<AreaConsolidada>();
    }

    public static IReadOnlyList<AreaConsolidada> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaConsolidada
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaConsolidada>)sqlConnection.Query<AreaConsolidada>(query, new { territorioId });
    }
}