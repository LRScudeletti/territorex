using Dapper;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Nivel;

namespace TerritorEx.Api.Repository;

public static class NivelRepository
{
    public static Nivel Criar(CriarNivel criarNivel)
    {
        using var sqlConnection = Utils.GetConnection();

        const string query = @"INSERT INTO Nivel 
                                      (NivelNome)
                               OUTPUT INSERTED.NivelId,
                               VALUES 
                                      (@NivelNome)";

       return sqlConnection.QuerySingle<Nivel>(query, criarNivel);
    }

    public static IEnumerable<Nivel> RecuperarTodos()
    {
        using var sqlConnection = Utils.GetConnection();

        const string query = @"SELECT NivelId,
                                      NivelNome
                                 FROM Nivel;";

        return sqlConnection.Query<Nivel>(query);
    }

    public static Nivel RecuperarPorId(int nivelId)
    {
        using var connection = Utils.GetConnection();

        const string query = @"SELECT NivelId,
                                      NivelNome
                                 FROM Nivel
                                WHERE NivelId = @NivelId;";

        return connection.QueryFirstOrDefault<Nivel>(query, new { nivelId });
    }
}

