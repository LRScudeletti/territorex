using TerritorEx.Api.Interfaces.Area;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories.Area;

namespace TerritorEx.Api.Services.Area;

public class AreaVegetacaoNativaService : IAreaVegetacaoNativa
{
    public IReadOnlyList<AreaVegetacaoNativa> RecuperarTodos()
    {
        var area = AreaVegetacaoNativaRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaVegetacaoNativa> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaVegetacaoNativaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}