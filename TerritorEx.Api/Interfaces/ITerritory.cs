using TerritorEx.Api.Models.Territory;

namespace TerritorEx.Api.Interfaces;

public interface ITerritory
{
    IEnumerable<Territory> ReadAll();

    Territory ReadById(int territoryId);

    IEnumerable<Territory> ReadByName(string territoryName);

    IEnumerable<Territory> ReadByParentId(int territoryParentId);

    IEnumerable<Territory> ReadByLevelId(int levelId);

    TerritoryHierarchy ReadHierarchy(int territoryId);
}

