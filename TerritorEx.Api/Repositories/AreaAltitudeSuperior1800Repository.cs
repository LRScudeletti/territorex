using Dapper;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaAltitudeSuperior1800Repository
{
    Task<IEnumerable<AreaAltitudeSuperior1800Model>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaAltitudeSuperior1800Model>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaAltitudeSuperior1800Repository : IAreaAltitudeSuperior1800Repository
{
    public async Task<IEnumerable<AreaAltitudeSuperior1800Model>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaAltitudeSuperior1800;";

        return await sqlConnection.QueryAsync<AreaAltitudeSuperior1800Model>(sql);
    }

    public async Task<IReadOnlyCollection<AreaAltitudeSuperior1800Model>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaAltitudeSuperior1800
                              WHERE TerritorioId = @territorioId;";

        return (IReadOnlyCollection<AreaAltitudeSuperior1800Model>)await sqlConnection
            .QueryAsync<AreaAltitudeSuperior1800Model>(sql, new { territorioId });
    }
}
#endregion