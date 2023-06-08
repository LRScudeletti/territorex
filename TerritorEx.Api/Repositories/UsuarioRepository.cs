using Dapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers;

namespace TerritorEx.Api.Repositories;

#region [ Interfaces ]
public interface IUsuarioRepository
{
    Task Criar(Usuario usuario);
    Task<IEnumerable<Usuario>> RecuperarTodos();
    Task<Usuario> RecuperarPorEmail(string email);
    Task Atualizar(Usuario usuario);
    Task Remover(string email);
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

        const string sql = @"SELECT Email,
                                    Nome,
                                    Sobrenome,
                                    Email,
                               FROM Usuario;";

        return await sqlConnection.QueryAsync<Usuario>(sql);
    }

    public async Task<Usuario> RecuperarPorEmail(string email)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"SELECT Email,
                                    Nome,
                                    Sobrenome,
                                    Senha
                               FROM Usuario
                              WHERE Email = @email;";

        return await sqlConnection.QuerySingleOrDefaultAsync<Usuario>(sql, new { email });
    }

    public async Task Atualizar(Usuario usuario)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"UPDATE Usuario 
                                SET Email = @Email, 
                                    Nome = @Nome,
                                    Sobrenome = @Sobrenome,
                                    PasswordHash = @PasswordHash,
                                    UsuarioAtualizacao = @UsuarioAtualizacao,   
                                    DataAtualizacao = @DataAtualizacao,   
                              WHERE UsuarioId = @UsuarioId;";

        await sqlConnection.ExecuteAsync(sql, usuario);
    }

    public async Task Remover(string email)
    {
        await using var sqlConnection = Utils.RecuperarConexao();

        const string sql = @"DELETE FROM Usuario WHERE Email = @email;";

        await sqlConnection.ExecuteAsync(sql, new { email });
    }
}
#endregion