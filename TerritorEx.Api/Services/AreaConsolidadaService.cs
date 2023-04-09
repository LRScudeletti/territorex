﻿using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaConsolidadaService
{
    Task<IEnumerable<AreaConsolidada>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaConsolidada>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Services ]
public class AreaConsolidadaService : IAreaConsolidadaService
{
    private readonly IAreaConsolidadaRepository _areaConsolidadaRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaConsolidadaService(IAreaConsolidadaRepository areaConsolidadaRepository, IStringLocalizer<Resources> localizer)
    {
        _areaConsolidadaRepository = areaConsolidadaRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaConsolidada>> RecuperarTodos()
    {
        return await _areaConsolidadaRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<AreaConsolidada>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaConsolidadaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_territorio_nao_encontrado"]);

        return area;
    }
}
#endregion