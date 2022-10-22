using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

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