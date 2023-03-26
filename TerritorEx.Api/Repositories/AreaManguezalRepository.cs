using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaManguezalRepository
{
    Task<IEnumerable<AreaManguezal>> RecuperarTodos();
    Task<IEnumerable<AreaManguezal>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaManguezalRepository : IAreaManguezalRepository
{
    public async Task<IEnumerable<AreaManguezal>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaManguezal;";

        return await sqlConnection.QueryAsync<AreaManguezal>(sql);
    }

    public async Task<IEnumerable<AreaManguezal>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaManguezal
                              WHERE TerritorioId = @territorioId;";

        return await sqlConnection.QueryAsync<AreaManguezal>(sql, new { territorioId });
    }
}
#endregion