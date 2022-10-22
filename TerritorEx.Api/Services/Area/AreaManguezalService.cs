using TerritorEx.Api.Interfaces.Area;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories.Area;

namespace TerritorEx.Api.Services.Area;

public class AreaManguezalService : IAreaManguezal
{
    public IReadOnlyList<AreaManguezal> RecuperarTodos()
    {
        var area = AreaManguezalRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaManguezal> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaManguezalRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}