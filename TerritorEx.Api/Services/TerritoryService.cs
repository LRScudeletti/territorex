using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repository;

namespace TerritorEx.Api.Services;

public class TerritoryService : ITerritory
{
    public IEnumerable<Territory> ReadAll()
    {
        return new TerritoryRepository().ReadAll();
    }
}