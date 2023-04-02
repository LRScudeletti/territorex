using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaServidaoAdministrativaRepository
{
    Task<IEnumerable<AreaServidaoAdministrativa>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaServidaoAdministrativa>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaServidaoAdministrativaRepository : IAreaServidaoAdministrativaRepository
{
    public async Task<IEnumerable<AreaServidaoAdministrativa>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaServidaoAdministrativa;";

        return await sqlConnection.QueryAsync<AreaServidaoAdministrativa>(sql);
    }

    public async Task<IReadOnlyCollection<AreaServidaoAdministrativa>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaServidaoAdministrativa
                              WHERE TerritorioId = @territorioId;";

        return (IReadOnlyCollection<AreaServidaoAdministrativa>)await sqlConnection
            .QueryAsync<AreaServidaoAdministrativa>(sql, new { territorioId });
    }
}
#endregion