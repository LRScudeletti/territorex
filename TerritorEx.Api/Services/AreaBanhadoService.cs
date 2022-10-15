using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaBanhadoService : IAreaBanhado
{
    public IEnumerable<AreaBanhado> RecuperarTodos()
    {
        var area = AreaBanhadoRepository.RecuperarTodos();

        if (area == null)
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IEnumerable<AreaBanhado> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaBanhadoRepository.RecuperarPorTerritorioId(territorioId);

        if (area == null)
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}