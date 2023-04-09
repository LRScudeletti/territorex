using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaVeredaService
{
    Task<IEnumerable<AreaVereda>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaVereda>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Services ]
public class AreaVeredaService : IAreaVeredaService
{
    private readonly IAreaVeredaRepository _areaVeredaRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaVeredaService(IAreaVeredaRepository areaVeredaRepository, IStringLocalizer<Resources> localizer)
    {
        _areaVeredaRepository = areaVeredaRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaVereda>> RecuperarTodos()
    {
        return await _areaVeredaRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<AreaVereda>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaVeredaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_territorio_nao_encontrado"]);

        return area;
    }
}
#endregion