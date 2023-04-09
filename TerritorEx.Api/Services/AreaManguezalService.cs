using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaManguezalService
{
    Task<IEnumerable<AreaManguezal>> RecuperarTodos();
    Task<IEnumerable<AreaManguezal>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Services ]
public class AreaManguezalService : IAreaManguezalService
{
    private readonly IAreaManguezalRepository _areaManguezalRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaManguezalService(IAreaManguezalRepository areaManguezalRepository, IStringLocalizer<Resources> localizer)
    {
        _areaManguezalRepository = areaManguezalRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaManguezal>> RecuperarTodos()
    {
        return await _areaManguezalRepository.RecuperarTodos();
    }

    public async Task<IEnumerable<AreaManguezal>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaManguezalRepository.RecuperarPorTerritorioId(territorioId);

        if (area == null)
            throw new KeyNotFoundException(_localizer["area_territorio_nao_encontrado"]);

        return area;
    }
}
#endregion