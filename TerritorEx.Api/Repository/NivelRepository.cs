using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Nivel;

namespace TerritorEx.Api.Repository;

public static class NivelRepository
{
    public static IEnumerable<Nivel> RecuperarTodos()
    {
        using var sqlConnection = Utils.GetConnection();

        return sqlConnection.GetAll<Nivel>();
    }

    public static Nivel RecuperarPorId(int nivelId)
    {
        using var connection = Utils.GetConnection();

        return connection.Get<Nivel>(nivelId);
    }
}

