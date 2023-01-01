using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Repositories;

public static class NivelTerritorioRepository
{
    public static IReadOnlyList<NivelTerritorio> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<NivelTerritorio>)sqlConnection.GetAll<NivelTerritorio>();
    }

    public static NivelTerritorio RecuperarPorId(int nivelTerritorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return sqlConnection.Get<NivelTerritorio>(nivelTerritorioId);
    }
}

