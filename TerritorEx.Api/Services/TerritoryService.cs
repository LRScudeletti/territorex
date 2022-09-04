using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.Territory;
using TerritorEx.Api.Repository;

namespace TerritorEx.Api.Services;

public class TerritoryService : ITerritory
{
    public IEnumerable<Territory> ReadAll()
    {
        var territory = new TerritoryRepository().ReadAll();

        if (territory == null)
            throw new KeyNotFoundException(Properties.Resources.TerritoryNotFound);

        return territory;
    }

    public Territory ReadById(int territoryId)
    {
        var territory = new TerritoryRepository().ReadById(territoryId);

        if (territory == null)
            throw new KeyNotFoundException(Properties.Resources.TerritoryNotFound);

        return territory;
    }

    public IEnumerable<Territory> ReadByName(string territoryName)
    {
        var territory = new TerritoryRepository().ReadByName(territoryName);

        if (territory == null)
            throw new KeyNotFoundException(Properties.Resources.TerritoryNotFound);

        return territory;
    }

    public IEnumerable<Territory> ReadByParentId(int territoryParentId)
    {
        var territory = new TerritoryRepository().ReadByParentId(territoryParentId);

        if (territory == null)
            throw new KeyNotFoundException(Properties.Resources.TerritoryNotFound);

        return territory;
    }

    public IEnumerable<Territory> ReadByLevelId(int levelId)
    {
        var territory = new TerritoryRepository().ReadByLevelId(levelId);

        if (territory == null)
            throw new KeyNotFoundException(Properties.Resources.TerritoryNotFound);

        return territory;
    }

    public TerritoryHierarchy ReadHierarchy(int territoryId)
    {
        var territory = new TerritoryRepository().ReadHierarchy(territoryId);

        if (territory == null)
            throw new KeyNotFoundException(Properties.Resources.TerritoryNotFound);

        return territory;
    }
}