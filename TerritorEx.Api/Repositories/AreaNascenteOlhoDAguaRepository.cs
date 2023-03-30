using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaNascenteOlhoDAguaRepository
{
    Task<IEnumerable<AreaNascenteOlhoDAgua>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaNascenteOlhoDAgua>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaNascenteOlhoDAguaRepository : IAreaNascenteOlhoDAguaRepository
{
    public async Task<IEnumerable<AreaNascenteOlhoDAgua>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaNascenteOlhoDAgua;";

        return await sqlConnection.QueryAsync<AreaNascenteOlhoDAgua>(sql);
    }

    public async Task<IReadOnlyCollection<AreaNascenteOlhoDAgua>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaNascenteOlhoDAgua
                              WHERE TerritorioId = @territorioId;";

        return (IReadOnlyCollection<AreaNascenteOlhoDAgua>)await sqlConnection
            .QueryAsync<AreaNascenteOlhoDAgua>(sql, new { territorioId });
    }
}
#endregion