using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaHidrografiaRepository
{
    Task<IEnumerable<AreaHidrografia>> RecuperarTodos();
    Task<IReadOnlyList<AreaHidrografia>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaHidrografiaRepository : IAreaHidrografiaRepository
{
    public async Task<IEnumerable<AreaHidrografia>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaHidrografia;";

        return await sqlConnection.QueryAsync<AreaHidrografia>(sql);
    }

    public async Task<IReadOnlyList<AreaHidrografia>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaHidrografia
                              WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaHidrografia>)await sqlConnection
            .QueryAsync<AreaHidrografia>(sql, new { territorioId });
    }
}
#endregion