using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface ITerritorioRepository
{
    Task<IEnumerable<Territorio>> RecuperarTodos();
    Task<IReadOnlyCollection<Territorio>> RecuperarPorId(int territorioId);
    Task<IReadOnlyCollection<Territorio>> RecuperarPorNome(string territorioNome);
    Task<IReadOnlyCollection<Territorio>> RecuperarPorTerritorioSuperiorId(int territorioSuperiotId);
    Task<IReadOnlyCollection<Territorio>> RecuperarPorNivelId(int nivelTerritorioId);
    Task<TerritorioHierarquia> RecuperarHierarquia(int territorioId);
}
#endregion

#region [ Repositories ]
public class TerritorioRepository : ITerritorioRepository
{
    public async Task<IEnumerable<Territorio>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT TerritorioId,
                                    TerritorioNome,
                                    TerritorioSuperiorId,
                                    NivelTerritorioId,
                                    Latitude,
                                    Longitude,
                                    Shape
                               FROM Territorio;";

        return await sqlConnection.QueryAsync<Territorio>(sql);
    }

    public async Task<IReadOnlyCollection<Territorio>> RecuperarPorId(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT TerritorioId,
                                    TerritorioNome,
                                    TerritorioSuperiorId,
                                    NivelTerritorioId,
                                    Latitude,
                                    Longitude,
                                    Shape
                               FROM Territorio
                              WHERE TerritorioId = @territorioId;";

        return (IReadOnlyCollection<Territorio>)await sqlConnection
            .QueryAsync<Territorio>(sql, new { territorioId });
    }

    public async Task<IReadOnlyCollection<Territorio>> RecuperarPorNome(string territorioNome)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT TerritorioId,
                                      TerritorioNome,
                                      TerritorioSuperiorId,
                                      NivelTerritorioId,
                                      Latitude,
                                      Longitude,
                                      Shape
                                 FROM Territorio
                                WHERE UPPER(TerritorioNome) LIKE UPPER(@territorioNome);";

        return (IReadOnlyCollection<Territorio>)sqlConnection.Query<Territorio>(sql, new
        {
            territorioNome = string.Concat("%", territorioNome, "%")
        });
    }

    public async Task<IReadOnlyCollection<Territorio>> RecuperarPorTerritorioSuperiorId(int territorioSuperiotId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT TerritorioId,
                                    TerritorioNome,
                                    TerritorioSuperiorId,
                                    NivelTerritorioId,
                                    Latitude,
                                    Longitude,
                                    Shape
                               FROM Territorio
                              WHERE TerritorioSuperiorId = @territorioSuperiotId;";

        return (IReadOnlyCollection<Territorio>)sqlConnection.Query<Territorio>(sql, new { territorioSuperiotId });
    }

    public async Task<IReadOnlyCollection<Territorio>> RecuperarPorNivelId(int nivelTerritorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT TerritorioId,
                                    TerritorioNome,
                                    TerritorioSuperiorId,
                                    NivelTerritorioId,
                                    Latitude,
                                    Longitude,
                                    Shape
                               FROM Territorio
                              WHERE NivelTerritorioId = @nivelTerritorioId;";

        return (IReadOnlyCollection<Territorio>)sqlConnection.Query<Territorio>(sql, new { nivelTerritorioId });
    }

    public async Task<TerritorioHierarquia> RecuperarHierarquia(int territorioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT * 
                                 FROM ViewTerritorioHierarquia
                                WHERE TerritorioId = @territorioId;";

        return sqlConnection.QueryFirstOrDefault<TerritorioHierarquia>(query, new { territorioId });
    }
}
#endregion