﻿using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaDeclividadeMaior45Service
{
    Task<IEnumerable<AreaDeclividadeMaior45>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaDeclividadeMaior45>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Services ]
public class AreaDeclividadeMaior45Service : IAreaDeclividadeMaior45Service
{
    private readonly IAreaDeclividadeMaior45Repository _areaDeclividadeMaior45Repository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaDeclividadeMaior45Service(IAreaDeclividadeMaior45Repository areaDeclividadeMaior45Repository, IStringLocalizer<Resources> localizer)
    {
        _areaDeclividadeMaior45Repository = areaDeclividadeMaior45Repository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaDeclividadeMaior45>> RecuperarTodos()
    {
        return await _areaDeclividadeMaior45Repository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<AreaDeclividadeMaior45>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaDeclividadeMaior45Repository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_territorio_nao_encontrado"]);

        return area;
    }
}
#endregion