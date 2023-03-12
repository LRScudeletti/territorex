using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaDeclividadeMaior45Repository
{
    Task<IEnumerable<AreaDeclividadeMaior45>> RecuperarTodos();
    Task<IEnumerable<AreaDeclividadeMaior45>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaDeclividadeMaior45Repository : IAreaDeclividadeMaior45Repository
{
    public async Task<IEnumerable<AreaDeclividadeMaior45>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaDeclividadeMaior45;";

        return await sqlConnection.QueryAsync<AreaDeclividadeMaior45>(sql);
    }

    public async Task<IEnumerable<AreaDeclividadeMaior45>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaDeclividadeMaior45
                              WHERE TerritorioId = @territorioId;";

        return await sqlConnection.QueryAsync<AreaDeclividadeMaior45>(sql, new { territorioId });
    }
}
#endregion