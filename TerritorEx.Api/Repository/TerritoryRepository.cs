using Dapper;
using System.Text;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Repository;

public class TerritoryRepository
{
    public IEnumerable<Territory> ReadAll()
    {
        using var sqlConnection = SqlHelper.GetConnection();
        sqlConnection.Open();

        var query = new StringBuilder();
        query.AppendLine("SELECT * FROM Territory;");

        return sqlConnection.Query<Territory>(sql:query.ToString());
    }
}

