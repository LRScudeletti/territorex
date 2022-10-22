using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.AreaTerritorial;

namespace TerritorEx.Api.Repositories.AreaTerritorial;

public static class NivelTerritorioRepository
{
    public static IReadOnlyList<NivelTerritorio> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<NivelTerritorio>)sqlConnection.GetAll<NivelTerritorio>();
    }

    public static NivelTerritorio RecuperarPorId(int nivelTerritorioId)
    {
        using var connection = Utils.RecuperarConexao();

        return connection.Get<NivelTerritorio>(nivelTerritorioId);
    }
}

