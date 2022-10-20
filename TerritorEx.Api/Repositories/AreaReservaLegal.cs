using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Repositories;

public static class AreaReservaLegalRepository
{
    public static IReadOnlyList<AreaReservaLegal> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaReservaLegal>)sqlConnection.GetAll<AreaReservaLegal>();
    }

    public static IReadOnlyList<AreaReservaLegal> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaReservaLegal
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaReservaLegal>)sqlConnection.Query<AreaReservaLegal>(query, new { territorioId });
    }
}