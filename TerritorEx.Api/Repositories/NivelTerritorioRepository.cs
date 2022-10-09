using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.NivelTerritorio;

namespace TerritorEx.Api.Repositories;

public static class NivelTerritorioRepository
{
    public static IEnumerable<NivelTerritorio> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return sqlConnection.GetAll<NivelTerritorio>();
    }

    public static NivelTerritorio RecuperarPorId(int nivelTerritorioId)
    {
        using var connection = Utils.RecuperarConexao();

        return connection.Get<NivelTerritorio>(nivelTerritorioId);
    }
}

