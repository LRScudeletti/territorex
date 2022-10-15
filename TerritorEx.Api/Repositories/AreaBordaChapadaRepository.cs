using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Repositories;

public static class AreaBordaChapadaRepository
{
    public static IReadOnlyList<AreaBordaChapada> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaBordaChapada>)sqlConnection.GetAll<AreaBordaChapada>();
    }

    public static IReadOnlyList<AreaBordaChapada> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaBordaChapada
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaBordaChapada>)sqlConnection.Query<AreaBordaChapada>(query, new { territorioId });
    }
}