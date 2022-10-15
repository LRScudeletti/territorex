using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaHidrografiaService : IAreaHidrografia
{
    public IReadOnlyList<AreaHidrografia> RecuperarTodos()
    {
        var area = AreaHidrografiaRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaHidrografia> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaHidrografiaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}