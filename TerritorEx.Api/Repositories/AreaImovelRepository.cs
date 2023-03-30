﻿using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaImovelRepository
{
    Task<IEnumerable<AreaImovel>> RecuperarTodos();
    Task<IReadOnlyList<AreaImovel>> RecuperarPorTerritorioId(int territorioId);
    Task<AreaImovel> RecuperarPorImovelId(string imovelId);
    Task<IReadOnlyList<AreaImovel>> RecuperarPorTipoImovelId(int tipoImovelId);
    Task<IReadOnlyList<AreaImovel>> RecuperarPorSituacaoImovelId(int situacaoImovelId);
}
#endregion

#region [ Repositories ]
public class AreaImovelRepository : IAreaImovelRepository
{
    public async Task<IEnumerable<AreaImovel>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      ImovelId,
                                      TipoImovelId,
                                      SituacaoImovelId,
                                      Condicao,
                                      AreaHectare,
                                      ModuloFiscal,
                                      Shape
                                 FROM AreaImovel;";

        return await sqlConnection.QueryAsync<AreaImovel>(query);
    }

    public async Task<IReadOnlyList<AreaImovel>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      ImovelId,
                                      TipoImovelId,
                                      SituacaoImovelId,
                                      Condicao,
                                      AreaHectare,
                                      ModuloFiscal,
                                      Shape
                                 FROM AreaImovel
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaImovel>)await sqlConnection
            .QueryAsync<AreaImovel>(query, new { territorioId });
    }

    public async Task<AreaImovel> RecuperarPorImovelId(string imovelId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      ImovelId,
                                      TipoImovelId,
                                      SituacaoImovelId,
                                      Condicao,
                                      AreaHectare,
                                      ModuloFiscal,
                                      Shape
                                 FROM AreaImovel
                                WHERE ImovelId = @imovelId;";

        return await sqlConnection.QuerySingleOrDefaultAsync<AreaImovel>(query, new { imovelId });
    }

    public async Task<IReadOnlyList<AreaImovel>> RecuperarPorTipoImovelId(int tipoImovelId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      ImovelId,
                                      TipoImovelId,
                                      SituacaoImovelId,
                                      Condicao,
                                      AreaHectare,
                                      ModuloFiscal,
                                      Shape
                                 FROM AreaImovel
                                WHERE TipoImovelId = @tipoImovelId;";

        return (IReadOnlyList<AreaImovel>)await sqlConnection
            .QueryAsync<AreaImovel>(query, new { tipoImovelId });
    }

    public async Task<IReadOnlyList<AreaImovel>> RecuperarPorSituacaoImovelId(int situacaoImovelId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      ImovelId,
                                      TipoImovelId,
                                      SituacaoImovelId,
                                      Condicao,
                                      AreaHectare,
                                      ModuloFiscal,
                                      Shape
                                 FROM AreaImovel
                                WHERE SituacaoImovelId = @situacaoImovelId;";

        return (IReadOnlyList<AreaImovel>)await sqlConnection
            .QueryAsync<AreaImovel>(query, new { situacaoImovelId });
    }
}
#endregion