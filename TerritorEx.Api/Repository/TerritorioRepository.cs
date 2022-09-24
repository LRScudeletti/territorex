using Dapper;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Territorio;

namespace TerritorEx.Api.Repository;

public static class TerritorioRepository
{
    public static IEnumerable<Territorio> RecuperarTodos()
    {
        using var sqlConnection = Utils.GetConnection();

        const string query = @"SELECT TerritorioId,
                                      TerritorioNome,
                                      TerritorioPaiId,
                                      NivelId,
                                      Latitude,
                                      Latitude,
                                      Longitude,
                                      Shape
                                 FROM Territorio;";

        return sqlConnection.Query<Territorio>(query);
    }

    public static Territorio RecuperarPorId(int territorioId)
    {
        using var connection = Utils.GetConnection();

        const string query = @"SELECT TerritorioId,
                                      TerritorioNome,
                                      TerritorioPaiId,
                                      NivelId,
                                      Latitude,
                                      Longitude,
                                      Shape
                                 FROM Territorio
                                WHERE TerritorioId = @territorioId;";

        return connection.QueryFirstOrDefault<Territorio>(query, new { territorioId });
    }

    public static IEnumerable<Territorio> RecuperarPorNome(string territorioNome)
    {
        using var sqlConnection = Utils.GetConnection();

        const string query = @"SELECT TerritorioId,
                                      TerritorioNome,
                                      TerritorioPaiId,
                                      NivelId,
                                      Latitude,
                                      Longitude,
                                      Shape
                                 FROM Territorio
                                WHERE UPPER(TerritorioNome) LIKE UPPER(@territorioNome);";

        return sqlConnection.Query<Territorio>(query, new
        {
            territorioNome = string.Concat("%", territorioNome, "%")
        });
    }

    public static IEnumerable<Territorio> RecuperarPorPaiId(int territorioPaiId)
    {
        using var sqlConnection = Utils.GetConnection();

        const string query = @"SELECT TerritorioId,
                                      TerritorioNome,
                                      TerritorioPaiId,
                                      NivelId,
                                      Latitude,
                                      Longitude,
                                      Shape
                                 FROM Territorio
                                WHERE TerritorioPaiId = @territorioPaiId;";

        return sqlConnection.Query<Territorio>(query, new { territorioPaiId });
    }

    public static IEnumerable<Territorio> RecuperarPorNivelId(int nivelId)
    {
        using var sqlConnection = Utils.GetConnection();

        const string query = @"SELECT TerritorioId,
                                      TerritorioNome,
                                      TerritorioPaiId,
                                      NivelId,
                                      Latitude,
                                      Longitude,
                                      Shape
                                 FROM Territorio
                                WHERE NivelId = @nivelId;";

        return sqlConnection.Query<Territorio>(query, new { nivelId });
    }

    public static TerritorioHierarquia RecuperarHierarquia(int territorioId)
    {
        using var sqlConnection = Utils.GetConnection();

        const string query = @"SELECT * 
                                 FROM ViewTerritorioHierarquia
                                WHERE TerritorioId = @territorioId;";

        return sqlConnection.QueryFirstOrDefault<TerritorioHierarquia>(query, new { territorioId });
    }
}

