using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaServidaoAdministrativaService : IAreaServidaoAdministrativa
{
    public IReadOnlyList<AreaServidaoAdministrativa> RecuperarTodos()
    {
        var area = AreaServidaoAdministrativaRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaServidaoAdministrativa> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaServidaoAdministrativaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}