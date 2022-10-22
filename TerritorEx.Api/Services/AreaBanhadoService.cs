using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

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