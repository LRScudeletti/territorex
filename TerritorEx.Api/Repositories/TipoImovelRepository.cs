using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Repositories;

public static class TipoImovelRepository
{
    public static IReadOnlyList<TipoImovel> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<TipoImovel>)sqlConnection.GetAll<TipoImovel>();
    }

    public static TipoImovel RecuperarPorId(int tipoImovelId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return sqlConnection.Get<TipoImovel>(tipoImovelId);
    }
}

