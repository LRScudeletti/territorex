using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Repositories;

public static class SituacaoImovelRepository
{
    public static IReadOnlyList<SituacaoImovel> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<SituacaoImovel>)sqlConnection.GetAll<SituacaoImovel>();
    }

    public static SituacaoImovel RecuperarPorId(int situacaoImovelId)
    {
        using var connection = Utils.RecuperarConexao();

        return connection.Get<SituacaoImovel>(situacaoImovelId);
    }
}

