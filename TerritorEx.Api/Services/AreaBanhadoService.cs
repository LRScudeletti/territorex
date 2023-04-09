using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaBanhadoService
{
    Task<IEnumerable<AreaBanhado>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaBanhado>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Services ]
public class AreaBanhadoService : IAreaBanhadoService
{
    private readonly IAreaBanhadoRepository _areaBanhadoRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaBanhadoService(IAreaBanhadoRepository areaBanhadoRepository, IStringLocalizer<Resources> localizer)
    {
        _areaBanhadoRepository = areaBanhadoRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaBanhado>> RecuperarTodos()
    {
        return await _areaBanhadoRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<AreaBanhado>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaBanhadoRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_territorio_nao_encontrado"]);

        return area;
    }
}
#endregion