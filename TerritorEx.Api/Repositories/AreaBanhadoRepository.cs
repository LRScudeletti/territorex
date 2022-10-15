using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Repositories;

public static class AreaBanhadoRepository
{
    public static IEnumerable<AreaBanhado> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return sqlConnection.GetAll<AreaBanhado>();
    }

    public static IEnumerable<AreaBanhado> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaBanhado
                                WHERE TerritorioId = @territorioId;";

        return sqlConnection.Query<AreaBanhado>(query, new { territorioId });
    }
}