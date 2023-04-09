using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaPreservacaoPermanenteService
{
    Task<IEnumerable<AreaPreservacaoPermanente>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaPreservacaoPermanente>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Services ]
public class AreaPreservacaoPermanenteService : IAreaPreservacaoPermanenteService
{
    private readonly IAreaPreservacaoPermanenteRepository _areaPreservacaoPermanenteRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaPreservacaoPermanenteService(IAreaPreservacaoPermanenteRepository areaPreservacaoPermanenteRepository, IStringLocalizer<Resources> localizer)
    {
        _areaPreservacaoPermanenteRepository = areaPreservacaoPermanenteRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaPreservacaoPermanente>> RecuperarTodos()
    {
        return await _areaPreservacaoPermanenteRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<AreaPreservacaoPermanente>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaPreservacaoPermanenteRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_territorio_nao_encontrado"]);

        return area;
    }
}
#endregion