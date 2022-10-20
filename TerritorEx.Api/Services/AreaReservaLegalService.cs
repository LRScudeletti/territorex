using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaReservaLegalService : IAreaReservaLegal
{
    public IReadOnlyList<AreaReservaLegal> RecuperarTodos()
    {
        var area = AreaReservaLegalRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaReservaLegal> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaReservaLegalRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}