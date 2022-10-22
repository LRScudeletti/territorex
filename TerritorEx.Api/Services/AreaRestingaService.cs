using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaRestingaService : IAreaRestinga
{
    public IReadOnlyList<AreaRestinga> RecuperarTodos()
    {
        var area = AreaRestingaRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaRestinga> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaRestingaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}