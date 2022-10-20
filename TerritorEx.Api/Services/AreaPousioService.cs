using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaAreaPousio : IAreaPousio
{
    public IReadOnlyList<AreaPousio> RecuperarTodos()
    {
        var area = AreaPousioRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaPousio> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaPousioRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}