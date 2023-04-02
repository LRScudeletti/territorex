using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaServidaoAdministrativaService
{
    Task<IEnumerable<AreaServidaoAdministrativa>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaServidaoAdministrativa>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Services ]
public class AreaServidaoAdministrativaService : IAreaServidaoAdministrativaService
{
    private readonly IAreaServidaoAdministrativaRepository _areaServidaoAdministrativaRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaServidaoAdministrativaService(IAreaServidaoAdministrativaRepository areaServidaoAdministrativaRepository, IStringLocalizer<Resources> localizer)
    {
        _areaServidaoAdministrativaRepository = areaServidaoAdministrativaRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaServidaoAdministrativa>> RecuperarTodos()
    {
        return await _areaServidaoAdministrativaRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<AreaServidaoAdministrativa>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaServidaoAdministrativaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }
}
#endregion