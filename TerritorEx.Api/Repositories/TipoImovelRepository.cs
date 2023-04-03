using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface ITipoImovelRepository
{
    Task<IEnumerable<TipoImovel>> RecuperarTodos();
    Task<IReadOnlyCollection<TipoImovel>> RecuperarPorId(int tipoImovelId);
}
#endregion

#region [ Repositories ]
public class TipoImovelRepository : ITipoImovelRepository
{
    public async Task<IEnumerable<TipoImovel>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT TipoImovelId,
                                    Sigla,
                                    Descricao
                               FROM TipoImovel;";

        return await sqlConnection.QueryAsync<TipoImovel>(sql);
    }

    public async Task<IReadOnlyCollection<TipoImovel>> RecuperarPorId(int tipoImovelId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT TipoImovelId,
                                    Sigla,
                                    Descricao
                               FROM TipoImovel;
                              WHERE TipoImovelId = @tipoImovelId;";

        return (IReadOnlyCollection<TipoImovel>)await sqlConnection
            .QueryAsync<TipoImovel>(sql, new { tipoImovelId });
    }
}
#endregion