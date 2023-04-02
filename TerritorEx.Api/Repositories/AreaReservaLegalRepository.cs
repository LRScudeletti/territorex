using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaReservaLegalRepository
{
    Task<IEnumerable<AreaReservaLegal>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaReservaLegal>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaReservaLegalRepository : IAreaReservaLegalRepository
{
    public async Task<IEnumerable<AreaReservaLegal>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaReservaLegal;";

        return await sqlConnection.QueryAsync<AreaReservaLegal>(sql);
    }

    public async Task<IReadOnlyCollection<AreaReservaLegal>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaReservaLegal
                              WHERE TerritorioId = @territorioId;";

        return (IReadOnlyCollection<AreaReservaLegal>)await sqlConnection
            .QueryAsync<AreaReservaLegal>(sql, new { territorioId });
    }
}
#endregion