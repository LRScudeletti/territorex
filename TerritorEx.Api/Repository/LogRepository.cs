using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Log;

namespace TerritorEx.Api.Repository;

public static class LogRepository
{
    public static void CriarLogErro(LogErro erro)
    {
        using var sqlConnection = Utils.GetConnection();

        sqlConnection.Insert(erro);
    }
}