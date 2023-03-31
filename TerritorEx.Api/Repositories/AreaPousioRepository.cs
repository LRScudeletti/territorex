using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaPousioRepository
{
    Task<IEnumerable<AreaPousio>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaPousio>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaPousioRepository : IAreaPousioRepository
{
    public async Task<IEnumerable<AreaPousio>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaPousio;";

        return await sqlConnection.QueryAsync<AreaPousio>(sql);
    }

    public async Task<IReadOnlyCollection<AreaPousio>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaPousio
                              WHERE TerritorioId = @territorioId;";

        return (IReadOnlyCollection<AreaPousio>)await sqlConnection
            .QueryAsync<AreaPousio>(sql, new { territorioId });
    }
}
#endregion