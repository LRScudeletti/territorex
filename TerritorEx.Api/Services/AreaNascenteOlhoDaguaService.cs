using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

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