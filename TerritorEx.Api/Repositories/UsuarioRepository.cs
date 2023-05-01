using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IUsuarioRepository
{
    Task Criar(Usuario usuario);
    Task<IEnumerable<Usuario>> RecuperarTodos();
    Task<Usuario> RecuperarPorId(int usuarioId);
    Task<Usuario> RecuperarPorEmail(string email);
    Task Atualizar(Usuario usuario);
    Task Remover(int usuarioId);
}
#endregion

#region [ Repositories ]
public class UsuarioRepository : IUsuarioRepository
{
    public async Task Criar(Usuario usuario)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"INSERT INTO Usuario (Nome, Sobrenome, Email, PasswordHash, UsuarioAtualizacao, DataAtualizacao)
                             VALUES (@Nome, @Sobrenome, @Email, @PasswordHash, @UsuarioAtualizacao, @DataAtualizacao);";

        await sqlConnection.ExecuteAsync(sql, usuario);
    }

    public async Task<IEnumerable<Usuario>> RecuperarTodos()
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT UsuarioId,
                                    Nome,
                                    Sobrenome,
                                    Email,
                               FROM Usuario;";

        return await sqlConnection.QueryAsync<Usuario>(sql);
    }

    public async Task<Usuario> RecuperarPorId(int usuarioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT UsuarioId,
                                    Nome,
                                    Sobrenome,
                                    Email,  
                              WHERE UsuarioId = @usuarioId;";

        return await sqlConnection.QuerySingleOrDefaultAsync<Usuario>(sql, new { usuarioId });
    }

    public async Task<Usuario> RecuperarPorEmail(string email)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT UsuarioId,
                                    Nome,
                                    Sobrenome,
                                    Email,  
                              WHERE Email = @email;";

        return await sqlConnection.QuerySingleOrDefaultAsync<Usuario>(sql, new { email });
    }

    public async Task Atualizar(Usuario usuario)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"UPDATE Usuario 
                                SET Nome = @Nome,
                                    Sobrenome = @Sobrenome,
                                    Email = @Email, 
                                    PasswordHash = @PasswordHash,
                                    UsuarioAtualizacao = @UsuarioAtualizacao,   
                                    DataAtualizacao = @DataAtualizacao,   
                              WHERE UsuarioId = @UsuarioId;";

        await sqlConnection.ExecuteAsync(sql, usuario);
    }

    public async Task Remover(int usuarioId)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"DELETE FROM Usuario WHERE UsuarioId = @usuarioId;";

        await sqlConnection.ExecuteAsync(sql, new { usuarioId });
    }
}
#endregion