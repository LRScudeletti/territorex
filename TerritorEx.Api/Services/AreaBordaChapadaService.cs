using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaBordaChapadaService
{
    Task<IEnumerable<AreaBordaChapada>> RecuperarTodos();
    Task<IEnumerable<AreaBordaChapada>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Services ]
public class AreaBordaChapadaService : IAreaBordaChapadaService
{
    private readonly IAreaBordaChapadaRepository _areaBordaChapadaRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaBordaChapadaService(
        IAreaBordaChapadaRepository areaBordaChapadaRepository,
        IStringLocalizer<Resources> localizer)
    {
        _areaBordaChapadaRepository = areaBordaChapadaRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaBordaChapada>> RecuperarTodos()
    {
        return await _areaBordaChapadaRepository.RecuperarTodos();
    }

    public async Task<IEnumerable<AreaBordaChapada>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaBordaChapadaRepository.RecuperarPorTerritorioId(territorioId);

        if (area == null)
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }
}
#endregion