using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Repositories;

public static class AreaBanhadoRepository
{
    public static IReadOnlyList<AreaBanhado> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaBanhado>)sqlConnection.GetAll<AreaBanhado>();
    }

    public static IReadOnlyList<AreaBanhado> RecuperarPorTerritorioId(int territorioId)
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

        return (IReadOnlyList<AreaBanhado>)sqlConnection.Query<AreaBanhado>(query, new { territorioId });
    }
}