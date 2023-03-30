using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaHidrografiaService
{
    Task<IEnumerable<AreaHidrografia>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaHidrografia>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Services ]
public class AreaHidrografiaService : IAreaHidrografiaService
{
    private readonly IAreaHidrografiaRepository _areaHidrografiaRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaHidrografiaService(IAreaHidrografiaRepository areaHidrografiaRepository, IStringLocalizer<Resources> localizer)
    {
        _areaHidrografiaRepository = areaHidrografiaRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaHidrografia>> RecuperarTodos()
    {
        return await _areaHidrografiaRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<AreaHidrografia>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaHidrografiaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }
}
#endregion