using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface ITerritory
{
    IEnumerable<Territory> ReadAll();
}

