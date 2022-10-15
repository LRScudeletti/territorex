using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaDeclividadeMaior45Service : IAreaDeclividadeMaior45
{
    public IReadOnlyList<AreaDeclividadeMaior45> RecuperarTodos()
    {
        var area = AreaDeclividadeMaior45Repository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaDeclividadeMaior45> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaDeclividadeMaior45Repository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}