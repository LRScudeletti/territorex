using TerritorEx.Api.Interfaces.Area;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories.Area;

namespace TerritorEx.Api.Services.Area;

public class AreaBanhadoService : IAreaBanhado
{
    public IReadOnlyList<AreaBanhado> RecuperarTodos()
    {
        var area = AreaBanhadoRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaBanhado> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaBanhadoRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}