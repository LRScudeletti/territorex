using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Territorio;

namespace TerritorEx.Api.Repository;

public static class TerritorioRepository
{
    public static IEnumerable<Territorio> RecuperarTodos()
    {
        using var sqlConnection = Utils.GetConnection();

        return sqlConnection.GetAll<Territorio>();
    }

    public static Territorio RecuperarPorId(int territorioId)
    {
        using var connection = Utils.GetConnection();

        return connection.Get<Territorio>(territorioId);
    }

    public static IEnumerable<Territorio> RecuperarPorNome(string territorioNome)
    {
        using var sqlConnection = Utils.GetConnection();

        const string query = @"SELECT Id,
                                      Nome,
                                      PaiId,
                                      NivelId,
                                      Latitude,
                                      Longitude,
                                      Shape
                                 FROM Territorio
                                WHERE UPPER(Nome) LIKE UPPER(@territorioNome);";

        return sqlConnection.Query<Territorio>(query, new
        {
            territorioNome = string.Concat("%", territorioNome, "%")
        });
    }

    public static IEnumerable<Territorio> RecuperarPorPaiId(int territorioPaiId)
    {
        using var sqlConnection = Utils.GetConnection();

        const string query = @"SELECT Id,
                                      Nome,
                                      PaiId,
                                      NivelId,
                                      Latitude,
                                      Longitude,
                                      Shape
                                 FROM Territorio
                                WHERE PaiId = @territorioPaiId;";

        return sqlConnection.Query<Territorio>(query, new { territorioPaiId });
    }

    public static IEnumerable<Territorio> RecuperarPorNivelId(int nivelId)
    {
        using var sqlConnection = Utils.GetConnection();

        const string query = @"SELECT Id,
                                      Nome,
                                      PaiId,
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

