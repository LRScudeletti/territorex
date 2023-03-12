using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaAltitudeSuperior1800Repository
{
    Task<IEnumerable<AreaAltitudeSuperior1800>> RecuperarTodos();
    Task<IEnumerable<AreaAltitudeSuperior1800>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaAltitudeSuperior1800Repository : IAreaAltitudeSuperior1800Repository
{
    public async Task<IEnumerable<AreaAltitudeSuperior1800>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaAltitudeSuperior1800;";

        return await sqlConnection.QueryAsync<AreaAltitudeSuperior1800>(sql);
    }

    public async Task<IEnumerable<AreaAltitudeSuperior1800>> RecuperarPorTerritorioId(int territorioId)
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

        return await sqlConnection.QueryAsync<AreaAltitudeSuperior1800>(sql, new { territorioId });
    }
}
#endregion