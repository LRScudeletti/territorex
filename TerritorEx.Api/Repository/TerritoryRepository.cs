using Dapper;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Territory;

namespace TerritorEx.Api.Repository;

public class TerritoryRepository
{
    public IEnumerable<Territory> ReadAll()
    {
        using var sqlConnection = Utils.GetConnection();

        const string query = @"SELECT TerritoryId,
                                      TerritoryName,
                                      TerritoryParentId,
                                      LevelId,
                                      Latitude,
                                      Latitude,
                                      Longitude,
                                      Shape
                                 FROM Territory;";

        return sqlConnection.Query<Territory>(query);
    }

    public Territory ReadById(int territoryId)
    {
        using var connection = Utils.GetConnection();

        const string query = @"SELECT TerritoryId,
                                      TerritoryName,
                                      TerritoryParentId,
                                      LevelId,
                                      Latitude,
                                      Latitude,
                                      Longitude,
                                      Shape
                                 FROM Territory
                                WHERE TerritoryId = @territoryId;";

        return connection.QueryFirstOrDefault<Territory>(query, new { territoryId });
    }

    public IEnumerable<Territory> ReadByName(string territoryName)
    {
        using var sqlConnection = Utils.GetConnection();

        const string query = @"SELECT TerritoryId,
                                      TerritoryName,
                                      TerritoryParentId,
                                      LevelId,
                                      Latitude,
                                      Latitude,
                                      Longitude,
                                      Shape
                                 FROM Territory
                                WHERE UPPER(TerritoryName) LIKE UPPER(@territoryName);";

        return sqlConnection.Query<Territory>(query, new
        {
            territoryName = string.Concat("%", territoryName, "%")
        });
    }

    public IEnumerable<Territory> ReadByParentId(int territoryParentId)
    {
        using var sqlConnection = Utils.GetConnection();

        const string query = @"SELECT TerritoryId,
                                      TerritoryName,
                                      TerritoryParentId,
                                      LevelId,
                                      Latitude,
                                      Latitude,
                                      Longitude,
                                      Shape
                                 FROM Territory
                                WHERE TerritoryParentId = @territoryParentId;";

        return sqlConnection.Query<Territory>(query, new { territoryParentId });
    }

    public IEnumerable<Territory> ReadByLevelId(int levelId)
    {
        using var sqlConnection = Utils.GetConnection();

        const string query = @"SELECT TerritoryId,
                                      TerritoryName,
                                      TerritoryParentId,
                                      LevelId,
                                      Latitude,
                                      Latitude,
                                      Longitude,
                                      Shape
                                 FROM Territory
                                WHERE LevelId = @levelId;";

        return sqlConnection.Query<Territory>(query, new { levelId });
    }

    public TerritoryHierarchy ReadHierarchy(int territoryId)
    {
        using var sqlConnection = Utils.GetConnection();

        const string query = @"SELECT * 
                                 FROM ViewTerritoryHierarchy
                                WHERE TerritoryId = @territoryId;";

        return sqlConnection.QueryFirstOrDefault<TerritoryHierarchy>(query, new { territoryId });
    }
}

