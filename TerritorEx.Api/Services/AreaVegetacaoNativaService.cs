using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaVegetacaoNativaService
{
    Task<IEnumerable<AreaVegetacaoNativa>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaVegetacaoNativa>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Services ]
public class AreaVegetacaoNativaService : IAreaVegetacaoNativaService
{
    private readonly IAreaVegetacaoNativaRepository _areaVegetacaoNativaRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaVegetacaoNativaService(IAreaVegetacaoNativaRepository areaVegetacaoNativaRepository, IStringLocalizer<Resources> localizer)
    {
        _areaVegetacaoNativaRepository = areaVegetacaoNativaRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaVegetacaoNativa>> RecuperarTodos()
    {
        return await _areaVegetacaoNativaRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<AreaVegetacaoNativa>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaVegetacaoNativaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_territorio_nao_encontrado"]);

        return area;
    }
}
#endregion