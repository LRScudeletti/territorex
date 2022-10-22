using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaTopoMorroService : IAreaTopoMorro
{
    public IReadOnlyList<AreaTopoMorro> RecuperarTodos()
    {
        var area = AreaTopoMorroRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaTopoMorro> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaTopoMorroRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}