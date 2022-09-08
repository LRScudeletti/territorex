using Dapper;
using System.Text;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Repository;

public class LevelRepository
{
    public IEnumerable<Level> ReadAll()
    {
        using var sqlConnection = Utils.GetConnection();

        const string query = @"SELECT LevelId,
                                      LevelName
                                 FROM Level;";

        return sqlConnection.Query<Level>(query);
    }

    public Level ReadById(int levelId)
    {
        using var connection = Utils.GetConnection();

        const string query = @"SELECT LevelId,
                                      LevelName
                                 FROM Level
                                WHERE LevelId = @LevelId;";

        return connection.QueryFirstOrDefault<Level>(query, new { levelId });
    }
}

