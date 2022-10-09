using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Territorio;

namespace TerritorEx.Api.Repositories;

public static class TerritorioRepository
{
    public static IEnumerable<Territorio> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return sqlConnection.GetAll<Territorio>();
    }

    public static Territorio RecuperarPorId(int territorioId)
    {
        using var connection = Utils.RecuperarConexao();

        return connection.Get<Territorio>(territorioId);
    }

    public static IEnumerable<Territorio> RecuperarPorNome(string territorioNome)
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

        return sqlConnection.Query<Territorio>(query, new
        {
            territorioNome = string.Concat("%", territorioNome, "%")
        });
    }

    public static IEnumerable<Territorio> RecuperarPorPaiId(int territorioPaiId)
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
                                WHERE TerritorioPaiId = @territorioPaiId;";

        return sqlConnection.Query<Territorio>(query, new { territorioPaiId });
    }

    public static IEnumerable<Territorio> RecuperarPorNivelTerritorioId(int nivelTerritorioId)
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

        return sqlConnection.Query<Territorio>(query, new { nivelTerritorioId });
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

