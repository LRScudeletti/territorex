using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaTopoMorroService
{
    Task<IEnumerable<AreaTopoMorro>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaTopoMorro>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Services ]
public class AreaTopoMorroService : IAreaTopoMorroService
{
    private readonly IAreaTopoMorroRepository _areaTopoMorroRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaTopoMorroService(IAreaTopoMorroRepository areaTopoMorroRepository, IStringLocalizer<Resources> localizer)
    {
        _areaTopoMorroRepository = areaTopoMorroRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaTopoMorro>> RecuperarTodos()
    {
        return await _areaTopoMorroRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<AreaTopoMorro>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaTopoMorroRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }
}
#endregion