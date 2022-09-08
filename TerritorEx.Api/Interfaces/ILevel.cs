using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface ILevel
{
    IEnumerable<Level> ReadAll();

    Level ReadById(int territoryId);
}

