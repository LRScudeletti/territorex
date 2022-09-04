using Dapper;
using System.Text;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Territory;

namespace TerritorEx.Api.Repository;

public class TerritoryRepository
{
    public IEnumerable<Territory> ReadAll()
    {
        using var sqlConnection = Utils.GetConnection();

        var query = new StringBuilder();
        query.AppendLine("SELECT TER.TerritoryId,");
        query.AppendLine("       TER.TerritoryName,");
        query.AppendLine("       TER.TerritoryParentId,");
        query.AppendLine("       TER.LevelId,");
        query.AppendLine("       TER.Latitude,");
        query.AppendLine("       TER.Latitude,");
        query.AppendLine("       TER.Longitude,");
        query.AppendLine("       TER.Shape");
        query.AppendLine("  FROM Territory AS TER;");

        return sqlConnection.Query<Territory>(query.ToString());
    }

    public Territory ReadById(int territoryId)
    {
        using var connection = Utils.GetConnection();

        var query = new StringBuilder();
        query.AppendLine("SELECT TER.TerritoryId,");
        query.AppendLine("       TER.TerritoryName,");
        query.AppendLine("       TER.TerritoryParentId,");
        query.AppendLine("       TER.LevelId,");
        query.AppendLine("       TER.Latitude,");
        query.AppendLine("       TER.Latitude,");
        query.AppendLine("       TER.Longitude,");
        query.AppendLine("       TER.Shape");
        query.AppendLine("  FROM Territory AS TER");
        query.AppendLine(" WHERE TER.TerritoryId = @TerritoryId;");

        return connection.QueryFirstOrDefault<Territory>(
            query.ToString(), new { territoryId });
    }

    public IEnumerable<Territory> ReadByName(string territoryName)
    {
        using var sqlConnection = Utils.GetConnection();

        var query = new StringBuilder();
        query.AppendLine("SELECT TER.TerritoryId,");
        query.AppendLine("       TER.TerritoryName,");
        query.AppendLine("       TER.TerritoryParentId,");
        query.AppendLine("       TER.LevelId,");
        query.AppendLine("       TER.Latitude,");
        query.AppendLine("       TER.Latitude,");
        query.AppendLine("       TER.Longitude,");
        query.AppendLine("       TER.Shape");
        query.AppendLine("  FROM Territory AS TER");
        query.AppendLine(" WHERE TER.TerritoryName LIKE '%@TerritoryName%';");

        return sqlConnection.Query<Territory>(query.ToString(), new { territoryName });
    }

    public IEnumerable<Territory> ReadByParentId(int territoryParentId)
    {
        using var sqlConnection = Utils.GetConnection();

        var query = new StringBuilder();
        query.AppendLine("SELECT TER.TerritoryId,");
        query.AppendLine("       TER.TerritoryName,");
        query.AppendLine("       TER.TerritoryParentId,");
        query.AppendLine("       TER.LevelId,");
        query.AppendLine("       TER.Latitude,");
        query.AppendLine("       TER.Latitude,");
        query.AppendLine("       TER.Longitude,");
        query.AppendLine("       TER.Shape");
        query.AppendLine("  FROM Territory AS TER");
        query.AppendLine(" WHERE TER.TerritoryParentId = @TerritoryParentId;");

        return sqlConnection.Query<Territory>(query.ToString(), new { territoryParentId });
    }

    public IEnumerable<Territory> ReadByLevelId(int levelId)
    {
        using var sqlConnection = Utils.GetConnection();

        var query = new StringBuilder();
        query.AppendLine("SELECT TER.TerritoryId,");
        query.AppendLine("       TER.TerritoryName,");
        query.AppendLine("       TER.TerritoryParentId,");
        query.AppendLine("       TER.LevelId,");
        query.AppendLine("       TER.Latitude,");
        query.AppendLine("       TER.Latitude,");
        query.AppendLine("       TER.Longitude,");
        query.AppendLine("       TER.Shape");
        query.AppendLine("  FROM Territory AS TER");
        query.AppendLine(" WHERE TER.LevelId = @LevelId;");

        return sqlConnection.Query<Territory>(query.ToString(), new { levelId });
    }

    public TerritoryHierarchy ReadHierarchy(int territoryId)
    {
        using var sqlConnection = Utils.GetConnection();

        var query = new StringBuilder();
        query.AppendLine("SELECT * ");
        query.AppendLine("  FROM ViewTerritoryHierarchy VTH");
        query.AppendLine(" WHERE VTH.TerritoryId = @TerritoryId;");

        return sqlConnection.QueryFirstOrDefault<TerritoryHierarchy>(
            query.ToString(), new { territoryId });
    }
}

