using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repository;

namespace TerritorEx.Api.Services;

public class LevelService : ILevel
{
    public IEnumerable<Level> ReadAll()
    {
        var level = new LevelRepository().ReadAll();

        if (level == null)
            throw new KeyNotFoundException(Properties.Resources.LevelNotFound);

        return level;
    }

    public Level ReadById(int levelId)
    {
        var level = new LevelRepository().ReadById(levelId);

        if (level == null)
            throw new KeyNotFoundException(Properties.Resources.LevelNotFound);

        return level;
    }
}