using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaBordaChapadaService : IAreaBordaChapada
{
    public IEnumerable<AreaBordaChapada> RecuperarTodos()
    {
        var area = AreaBordaChapadaRepository.RecuperarTodos();

        if (area == null)
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IEnumerable<AreaBordaChapada> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaBordaChapadaRepository.RecuperarPorTerritorioId(territorioId);

        if (area == null)
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}