using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaConsolidadaService : IAreaConsolidada
{
    public IReadOnlyList<AreaConsolidada> RecuperarTodos()
    {
        var area = AreaConsolidadaRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaConsolidada> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaConsolidadaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}