using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaAltitudeSuperior1800Service : IAreaAltitudeSuperior1800
{
    public IReadOnlyList<AreaAltitudeSuperior1800> RecuperarTodos()
    {
        var area = AreaAltitudeSuperior1800Repository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaAltitudeSuperior1800> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaAltitudeSuperior1800Repository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}