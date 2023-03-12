using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaImovelRepository
{
    Task<IEnumerable<AreaImovel>> RecuperarTodos();
    Task<IEnumerable<AreaImovel>> RecuperarPorTerritorioId(int territorioId);
    Task<AreaImovel> RecuperarPorImovelId(string imovelId);
    Task<IEnumerable<AreaImovel>> RecuperarPorTipoImovelId(int tipoImovelId);
    Task<IEnumerable<AreaImovel>> RecuperarPorSituacaoImovelId(int situacaoImovelId);
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

    public async Task<IEnumerable<AreaImovel>> RecuperarPorTerritorioId(int territorioId)
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

        return await sqlConnection.QueryAsync<AreaImovel>(query, new { territorioId });
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

    public async Task<IEnumerable<AreaImovel>> RecuperarPorTipoImovelId(int tipoImovelId)
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

        return await sqlConnection.QueryAsync<AreaImovel>(query, new { tipoImovelId });
    }

    public async Task<IEnumerable<AreaImovel>> RecuperarPorSituacaoImovelId(int situacaoImovelId)
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

        return await sqlConnection.QueryAsync<AreaImovel>(query, new { situacaoImovelId });
    }
}
#endregion