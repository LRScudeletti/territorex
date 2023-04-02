using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaVegetacaoNativaRepository
{
    Task<IEnumerable<AreaVegetacaoNativa>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaVegetacaoNativa>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaVegetacaoNativaRepository : IAreaVegetacaoNativaRepository
{
    public async Task<IEnumerable<AreaVegetacaoNativa>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaVegetacaoNativa;";

        return await sqlConnection.QueryAsync<AreaVegetacaoNativa>(sql);
    }

    public async Task<IReadOnlyCollection<AreaVegetacaoNativa>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaVegetacaoNativa
                              WHERE TerritorioId = @territorioId;";

        return (IReadOnlyCollection<AreaVegetacaoNativa>)await sqlConnection
            .QueryAsync<AreaVegetacaoNativa>(sql, new { territorioId });
    }
}
#endregion