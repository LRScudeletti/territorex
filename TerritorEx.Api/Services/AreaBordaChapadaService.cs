using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaBordaChapadaService : IAreaBordaChapada
{
    public IReadOnlyList<AreaBordaChapada> RecuperarTodos()
    {
        var area = AreaBordaChapadaRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaBordaChapada> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaBordaChapadaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}