using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaVeredaRepository
{
    Task<IEnumerable<AreaVereda>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaVereda>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaVeredaRepository : IAreaVeredaRepository
{
    public async Task<IEnumerable<AreaVereda>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaVereda;";

        return await sqlConnection.QueryAsync<AreaVereda>(sql);
    }

    public async Task<IReadOnlyCollection<AreaVereda>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaVereda
                              WHERE TerritorioId = @territorioId;";

        return (IReadOnlyCollection<AreaVereda>)await sqlConnection
            .QueryAsync<AreaVereda>(sql, new { territorioId });
    }
}
#endregion