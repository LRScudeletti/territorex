using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface ISituacaoImovelRepository
{
    Task<IEnumerable<SituacaoImovel>> RecuperarTodos();
    Task<IReadOnlyCollection<SituacaoImovel>> RecuperarPorId(int nivelTerritorioId);
}
#endregion

#region [ Repositories ]
public class SituacaoImovelRepository : ISituacaoImovelRepository
{
    public async Task<IEnumerable<SituacaoImovel>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT SituacaoImovelId,
                                    Sigla,
                                    Descricao
                               FROM SituacaoImovel;";

        return await sqlConnection.QueryAsync<SituacaoImovel>(sql);
    }

    public async Task<IReadOnlyCollection<SituacaoImovel>> RecuperarPorId(int situacaoImovelId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT SituacaoImovelId,
                                    Sigla,
                                    Descricao
                               FROM SituacaoImovel;
                              WHERE SituacaoImovelId = @situacaoImovelId;";

        return (IReadOnlyCollection<SituacaoImovel>)await sqlConnection
            .QueryAsync<SituacaoImovel>(sql, new { situacaoImovelId });
    }
}
#endregion