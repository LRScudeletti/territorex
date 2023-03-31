using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaPousioService
{
    Task<IEnumerable<AreaPousio>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaPousio>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Services ]
public class AreaPousioService : IAreaPousioService
{
    private readonly IAreaPousioRepository _areaPousioRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaPousioService(IAreaPousioRepository areaPousioRepository, IStringLocalizer<Resources> localizer)
    {
        _areaPousioRepository = areaPousioRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaPousio>> RecuperarTodos()
    {
        return await _areaPousioRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<AreaPousio>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaPousioRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }
}
#endregion