using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Repositories;

public static class TerritorioRepository
{
    public static IReadOnlyList<Territorio> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<Territorio>)sqlConnection.GetAll<Territorio>();
    }

    public static Territorio RecuperarPorId(int territorioId)
    {
        using var connection = Utils.RecuperarConexao();

        return connection.Get<Territorio>(territorioId);
    }

    public static IReadOnlyList<Territorio> RecuperarPorNome(string territorioNome)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT TerritorioId,
                                      TerritorioNome,
                                      TerritorioPaiId,
                                      NivelTerritorioId,
                                      Latitude,
                                      Longitude,
                                      Shape
                                 FROM Territorio
                                WHERE UPPER(TerritorioNome) LIKE UPPER(@territorioNome);";

        return (IReadOnlyList<Territorio>)sqlConnection.Query<Territorio>(query, new
        {
            territorioNome = string.Concat("%", territorioNome, "%")
        });
    }

    public static IReadOnlyList<Territorio> RecuperarPorTerritorioSuperiorId(int territorioSuperiotId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT TerritorioId,
                                      TerritorioNome,
                                      TerritorioSuperiorId,
                                      NivelTerritorioId,
                                      Latitude,
                                      Longitude,
                                      Shape
                                 FROM Territorio
                                WHERE TerritorioSuperiorId = @territorioSuperiotId;";

        return (IReadOnlyList<Territorio>)sqlConnection.Query<Territorio>(query, new { territorioSuperiotId });
    }

    public static IReadOnlyList<Territorio> RecuperarPorNivelTerritorioId(int nivelTerritorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT TerritorioId,
                                      TerritorioNome,
                                      TerritorioPaiId,
                                      NivelTerritorioId,
                                      Latitude,
                                      Longitude,
                                      Shape
                                 FROM Territorio
                                WHERE NivelTerritorioId = @nivelTerritorioId;";

        return (IReadOnlyList<Territorio>)sqlConnection.Query<Territorio>(query, new { nivelTerritorioId });
    }

    public static TerritorioHierarquia RecuperarHierarquia(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT * 
                                 FROM ViewTerritorioHierarquia
                                WHERE TerritorioId = @territorioId;";

        return sqlConnection.QueryFirstOrDefault<TerritorioHierarquia>(query, new { territorioId });
    }
}

