using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaConsolidadaRepository
{
    Task<IEnumerable<AreaConsolidada>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaConsolidada>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaConsolidadaRepository : IAreaConsolidadaRepository
{
    public async Task<IEnumerable<AreaConsolidada>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaConsolidada;";

        return await sqlConnection.QueryAsync<AreaConsolidada>(sql);
    }

    public async Task<IReadOnlyCollection<AreaConsolidada>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaConsolidada
                              WHERE TerritorioId = @territorioId;";

        return (IReadOnlyCollection<AreaConsolidada>)await sqlConnection
            .QueryAsync<AreaConsolidada>(sql, new { territorioId });
    }
}
#endregion