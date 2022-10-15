using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Repositories;

public static class AreaAltitudeSuperior1800Repository
{
    public static IReadOnlyList<AreaAltitudeSuperior1800> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaAltitudeSuperior1800>)sqlConnection.GetAll<AreaAltitudeSuperior1800>();
    }

    public static IReadOnlyList<AreaAltitudeSuperior1800> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaAltitudeSuperior1800
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaAltitudeSuperior1800>)sqlConnection.Query<AreaAltitudeSuperior1800>(query, new { territorioId });
    }
}