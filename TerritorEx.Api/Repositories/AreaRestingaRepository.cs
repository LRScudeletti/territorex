using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaRestingaRepository
{
    Task<IEnumerable<AreaRestinga>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaRestinga>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaRestingaRepository : IAreaRestingaRepository
{
    public async Task<IEnumerable<AreaRestinga>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaRestinga;";

        return await sqlConnection.QueryAsync<AreaRestinga>(sql);
    }

    public async Task<IReadOnlyCollection<AreaRestinga>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaRestinga
                              WHERE TerritorioId = @territorioId;";

        return (IReadOnlyCollection<AreaRestinga>)await sqlConnection
            .QueryAsync<AreaRestinga>(sql, new { territorioId });
    }
}
#endregion