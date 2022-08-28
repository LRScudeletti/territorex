using Microsoft.Data.SqlClient;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Services;

public interface ITerritoryService
{
    void Create(TerritoryModel territoryCreateModel);
    IEnumerable<TerritoryModel> ReadAll();
    TerritoryModel ReadByTerritoryId(int territoryId);
    IEnumerable<TerritoryModel> ReadByContainsName(string territoryName);
    IEnumerable<TerritoryModel> ReadByParentId(int territoryParentId);
    IEnumerable<TerritoryModel> ReadByLevelId(int levelId);
    void Update(TerritoryModel territoryUpdateModel);
    void Delete(int territoryId);
}

public class TerritoryService : ITerritoryService
{
    private readonly IConfiguration _configuration;

    public TerritoryService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Create(TerritoryModel territoryCreateModel)
    {

    }

    public IEnumerable<TerritoryModel> ReadAll()
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("ApiDatabase"));

        connection.Open();

        using (var command = new SqlCommand())
        {
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM TERRITORIOS";

            var reader = command.ExecuteReader();

            while (reader.Read())
            {

            }

            reader.Close();
        }

        connection.Close();

        return null;
    }

    public TerritoryModel ReadByTerritoryId(int territoryId)
    {
        return null;
    }

    public IEnumerable<TerritoryModel> ReadByContainsName(string territoryName)
    {
        return null;
    }

    public IEnumerable<TerritoryModel> ReadByParentId(int territoryParentId)
    {
        return null;
    }

    public IEnumerable<TerritoryModel> ReadByLevelId(int levelId)
    {
        return null;
    }

    public void Update(TerritoryModel territoryUpdateModel)
    {

    }

    public void Delete(int territoryId)
    {

    }
}