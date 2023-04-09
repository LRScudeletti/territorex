using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaRestingaService
{
    Task<IEnumerable<AreaRestinga>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaRestinga>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Services ]
public class AreaRestingaService : IAreaRestingaService
{
    private readonly IAreaRestingaRepository _areaRestingaRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaRestingaService(IAreaRestingaRepository areaRestingaRepository, IStringLocalizer<Resources> localizer)
    {
        _areaRestingaRepository = areaRestingaRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaRestinga>> RecuperarTodos()
    {
        return await _areaRestingaRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<AreaRestinga>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaRestingaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_territorio_nao_encontrado"]);

        return area;
    }
}
#endregion