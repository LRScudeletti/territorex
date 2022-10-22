using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaUsoRestritoService : IAreaUsoRestrito
{
    public IReadOnlyList<AreaUsoRestrito> RecuperarTodos()
    {
        var area = AreaUsoRestritoRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaUsoRestrito> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaUsoRestritoRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}