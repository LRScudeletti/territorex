using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaBanhadoRepository
{
    Task<IEnumerable<AreaBanhado>> RecuperarTodos();
    Task<IReadOnlyList<AreaBanhado>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaBanhadoRepository : IAreaBanhadoRepository
{
    public async Task<IEnumerable<AreaBanhado>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaBanhado;";

        return await sqlConnection.QueryAsync<AreaBanhado>(sql);
    }

    public async Task<IReadOnlyList<AreaBanhado>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaBanhado
                              WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaBanhado>)await sqlConnection
            .QueryAsync<AreaBanhado>(sql, new { territorioId });
    }
}
#endregion