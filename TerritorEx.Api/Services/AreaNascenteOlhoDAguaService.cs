using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaNascenteOlhoDAguaService
{
    Task<IEnumerable<AreaNascenteOlhoDAgua>> RecuperarTodos();
    Task<IEnumerable<AreaNascenteOlhoDAgua>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Services ]
public class AreaNascenteOlhoDAguaService : IAreaNascenteOlhoDAguaService
{
    private readonly IAreaNascenteOlhoDAguaRepository _areaNascenteOlhoDAguaRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaNascenteOlhoDAguaService(IAreaNascenteOlhoDAguaRepository areaNascenteOlhoDAguaRepository, IStringLocalizer<Resources> localizer)
    {
        _areaNascenteOlhoDAguaRepository = areaNascenteOlhoDAguaRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaNascenteOlhoDAgua>> RecuperarTodos()
    {
        return await _areaNascenteOlhoDAguaRepository.RecuperarTodos();
    }

    public async Task<IEnumerable<AreaNascenteOlhoDAgua>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaNascenteOlhoDAguaRepository.RecuperarPorTerritorioId(territorioId);

        if (area == null)
            throw new KeyNotFoundException(_localizer["area_territorio_nao_encontrado"]);

        return area;
    }
}
#endregion