using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaAltitudeSuperior1800Service : IAreaAltitudeSuperior1800
{
    public IEnumerable<AreaAltitudeSuperior1800> RecuperarTodos()
    {
        var area = AreaAltitudeSuperior1800Repository.RecuperarTodos();

        if (area == null)
            throw new KeyNotFoundException(Properties.Resources.NivelTerritorioNaoEncontrado);

        return area;
    }

    public IEnumerable<AreaAltitudeSuperior1800> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaAltitudeSuperior1800Repository.RecuperarPorTerritorioId(territorioId);

        if (area == null)
            throw new KeyNotFoundException(Properties.Resources.NivelTerritorioNaoEncontrado);

        return area;
    }
}