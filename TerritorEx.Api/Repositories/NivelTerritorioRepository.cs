using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface INivelTerritorioRepository
{
    Task<IEnumerable<NivelTerritorio>> RecuperarTodos();
    Task<IReadOnlyCollection<NivelTerritorio>> RecuperarPorId(int nivelTerritorioId);
}
#endregion

#region [ Repositories ]
public class NivelTerritorioRepository : INivelTerritorioRepository
{
    public async Task<IEnumerable<NivelTerritorio>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT NivelTerritorioId,
                                    Sigla,
                                    Descricao
                               FROM NivelTerritorio;";

        return await sqlConnection.QueryAsync<NivelTerritorio>(sql);
    }

    public async Task<IReadOnlyCollection<NivelTerritorio>> RecuperarPorId(int nivelTerritorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT NivelTerritorioId,
                                    Sigla,
                                    Descricao
                               FROM NivelTerritorio;
                              WHERE NivelTerritorioId = @nivelTerritorioId;";

        return (IReadOnlyCollection<NivelTerritorio>)await sqlConnection
            .QueryAsync<NivelTerritorio>(sql, new { nivelTerritorioId });
    }
}
#endregion