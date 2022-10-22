using TerritorEx.Api.Interfaces.Area;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories.Area;

namespace TerritorEx.Api.Services.Area;

public class AreaNascenteOlhoDAguaService : IAreaNascenteOlhoDAgua
{
    public IReadOnlyList<AreaNascenteOlhoDAgua> RecuperarTodos()
    {
        var area = AreaNascenteOlhoDAguaRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaNascenteOlhoDAgua> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaNascenteOlhoDAguaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}