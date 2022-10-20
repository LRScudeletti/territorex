using Dapper;
using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Repositories;

public static class AreaPreservacaoPermanenteRepository
{
    public static IReadOnlyList<AreaPreservacaoPermanente> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        return (IReadOnlyList<AreaPreservacaoPermanente>)sqlConnection.GetAll<AreaPreservacaoPermanente>();
    }

    public static IReadOnlyList<AreaPreservacaoPermanente> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaPreservacaoPermanente
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaPreservacaoPermanente>)sqlConnection.Query<AreaPreservacaoPermanente>(query, new { territorioId });
    }
}