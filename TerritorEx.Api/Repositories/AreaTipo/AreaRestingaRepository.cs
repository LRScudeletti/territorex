using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Repositories.Area;

public static class AreaRestingaRepository
{
    public static IReadOnlyList<AreaRestinga> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaRestinga>)sqlConnection.GetAll<AreaRestinga>();
    }

    public static IReadOnlyList<AreaRestinga> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaRestinga
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaRestinga>)sqlConnection.Query<AreaRestinga>(query, new { territorioId });
    }
}