using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaTopoMorroRepository
{
    Task<IEnumerable<AreaTopoMorro>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaTopoMorro>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaTopoMorroRepository : IAreaTopoMorroRepository
{
    public async Task<IEnumerable<AreaTopoMorro>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaTopoMorro;";

        return await sqlConnection.QueryAsync<AreaTopoMorro>(sql);
    }

    public async Task<IReadOnlyCollection<AreaTopoMorro>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaTopoMorro
                              WHERE TerritorioId = @territorioId;";

        return (IReadOnlyCollection<AreaTopoMorro>)await sqlConnection
            .QueryAsync<AreaTopoMorro>(sql, new { territorioId });
    }
}
#endregion