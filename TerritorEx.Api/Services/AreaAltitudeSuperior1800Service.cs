using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaAltitudeSuperior1800Service
{
    Task<IEnumerable<AreaAltitudeSuperior1800>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaAltitudeSuperior1800>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Services ]
public class AreaAltitudeSuperior1800Service : IAreaAltitudeSuperior1800Service
{
    private readonly IAreaAltitudeSuperior1800Repository _areaAltitudeSuperior1800Repository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaAltitudeSuperior1800Service(IAreaAltitudeSuperior1800Repository areaAltitudeSuperior1800Repository, IStringLocalizer<Resources> localizer)
    {
        _areaAltitudeSuperior1800Repository = areaAltitudeSuperior1800Repository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaAltitudeSuperior1800>> RecuperarTodos()
    {
        return await _areaAltitudeSuperior1800Repository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<AreaAltitudeSuperior1800>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaAltitudeSuperior1800Repository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }
}
#endregion