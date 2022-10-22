using TerritorEx.Api.Interfaces.Area;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories.Area;

namespace TerritorEx.Api.Services.Area;

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