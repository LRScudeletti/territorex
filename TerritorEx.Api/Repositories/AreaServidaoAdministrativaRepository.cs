using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Repositories;

public static class AreaServidaoAdministrativaRepository
{
    public static IReadOnlyList<AreaServidaoAdministrativa> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaServidaoAdministrativa>)sqlConnection.GetAll<AreaServidaoAdministrativa>();
    }

    public static IReadOnlyList<AreaServidaoAdministrativa> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaServidaoAdministrativa
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaServidaoAdministrativa>)sqlConnection.Query<AreaServidaoAdministrativa>(query, new { territorioId });
    }
}