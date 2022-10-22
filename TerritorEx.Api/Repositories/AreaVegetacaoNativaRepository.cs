using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Repositories;

public static class AreaVegetacaoNativaRepository
{
    public static IReadOnlyList<AreaVegetacaoNativa> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaVegetacaoNativa>)sqlConnection.GetAll<AreaVegetacaoNativa>();
    }

    public static IReadOnlyList<AreaVegetacaoNativa> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaVegetacaoNativa
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaVegetacaoNativa>)sqlConnection.Query<AreaVegetacaoNativa>(query, new { territorioId });
    }
}