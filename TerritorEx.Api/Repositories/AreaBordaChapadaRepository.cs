using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaBordaChapadaRepository
{
    Task<IEnumerable<AreaBordaChapada>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaBordaChapada>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaBordaChapadaRepository : IAreaBordaChapadaRepository
{
    public async Task<IEnumerable<AreaBordaChapada>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaBordaChapada;";

        return await sqlConnection.QueryAsync<AreaBordaChapada>(sql);
    }

    public async Task<IReadOnlyCollection<AreaBordaChapada>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaBordaChapada
                              WHERE TerritorioId = @territorioId;";

        return (IReadOnlyCollection<AreaBordaChapada>)await sqlConnection
            .QueryAsync<AreaBordaChapada>(sql, new { territorioId });
    }
}
#endregion