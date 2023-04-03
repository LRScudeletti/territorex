using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface INivelTerritorioService
{
    Task<IEnumerable<NivelTerritorio>> RecuperarTodos();
    Task<IReadOnlyCollection<NivelTerritorio>> RecuperarPorId(int niveTerritorioId);
}
#endregion

#region [ Services ]
public class NivelTerritorioService : INivelTerritorioService
{
    private readonly INivelTerritorioRepository _nivelTerritorioRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public NivelTerritorioService(INivelTerritorioRepository nivelTerritorioRepository, IStringLocalizer<Resources> localizer)
    {
        _nivelTerritorioRepository = nivelTerritorioRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<NivelTerritorio>> RecuperarTodos()
    {
        return await _nivelTerritorioRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<NivelTerritorio>> RecuperarPorId(int niveTerritorioId)
    {
        var area = await _nivelTerritorioRepository.RecuperarPorId(niveTerritorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["nivel_nao_encontrado"]);

        return area;
    }
}
#endregion