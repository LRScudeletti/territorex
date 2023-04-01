using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IAreaPreservacaoPermanenteRepository
{
    Task<IEnumerable<AreaPreservacaoPermanente>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaPreservacaoPermanente>> RecuperarPorTerritorioId(int territorioId);
}
#endregion

#region [ Repositories ]
public class AreaPreservacaoPermanenteRepository : IAreaPreservacaoPermanenteRepository
{
    public async Task<IEnumerable<AreaPreservacaoPermanente>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaPreservacaoPermanente;";

        return await sqlConnection.QueryAsync<AreaPreservacaoPermanente>(sql);
    }

    public async Task<IReadOnlyCollection<AreaPreservacaoPermanente>> RecuperarPorTerritorioId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT AreaId,
                                    TerritorioId,
                                    SicarId,
                                    Descricao,
                                    AreaHectare,
                                    Shape
                               FROM AreaPreservacaoPermanente
                              WHERE TerritorioId = @territorioId;";

        return (IReadOnlyCollection<AreaPreservacaoPermanente>)await sqlConnection
            .QueryAsync<AreaPreservacaoPermanente>(sql, new { territorioId });
    }
}
#endregion