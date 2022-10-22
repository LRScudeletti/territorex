using TerritorEx.Api.Interfaces.Area;
using TerritorEx.Api.Models.Area;
using TerritorEx.Api.Repositories.Area;

namespace TerritorEx.Api.Services.Area;

public class AreaPreservacaoPermanenteService : IAreaPreservacaoPermanente
{
    public IReadOnlyList<AreaPreservacaoPermanente> RecuperarTodos()
    {
        var area = AreaPreservacaoPermanenteRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaPreservacaoPermanente> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaPreservacaoPermanenteRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}