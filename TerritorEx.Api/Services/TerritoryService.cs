using Dapper;
using System.Text;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Services;

public class TerritoryService : ITerritory
{
    public IEnumerable<Territory> ReadAll()
    {
        using var connection = SqlHelper.GetConnection();

        var query = new StringBuilder();
        query.AppendLine("SELECT TerritoryId,");
        query.AppendLine("       TerritoryName,");
        query.AppendLine("       TerritoryParentId,");
        query.AppendLine("       LevelId,");
        query.AppendLine("       Latitude,");
        query.AppendLine("       Latitude,");
        query.AppendLine("       Longitude,");
        query.AppendLine("       Shape");
        query.AppendLine("  FROM Territory;");

        return connection.Query<Territory>(query.ToString());
    }

    public Territory ReadByTerritoryId(int territoryId)
    {
        using var connection = SqlHelper.GetConnection();

        var query = new StringBuilder();
        query.AppendLine("SELECT TerritoryId,");
        query.AppendLine("       TerritoryName,");
        query.AppendLine("       TerritoryParentId,");
        query.AppendLine("       LevelId,");
        query.AppendLine("       Latitude,");
        query.AppendLine("       Latitude,");
        query.AppendLine("       Longitude,");
        query.AppendLine("       Shape");
        query.AppendLine("  FROM Territory");
        query.AppendLine(" WHERE TerritoryId = @TerritoryId;");

        return connection.QueryFirstOrDefault<Territory>(
            query.ToString(), new { territoryId });
    }
}