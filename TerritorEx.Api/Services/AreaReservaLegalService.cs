using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaReservaLegalService
{
    Task<IEnumerable<AreaReservaLegal>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaReservaLegal>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Services ]
public class AreaReservaLegalService : IAreaReservaLegalService
{
    private readonly IAreaReservaLegalRepository _areaReservaLegalRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaReservaLegalService(IAreaReservaLegalRepository areaReservaLegalRepository, IStringLocalizer<Resources> localizer)
    {
        _areaReservaLegalRepository = areaReservaLegalRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaReservaLegal>> RecuperarTodos()
    {
        return await _areaReservaLegalRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<AreaReservaLegal>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaReservaLegalRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }
}
#endregion