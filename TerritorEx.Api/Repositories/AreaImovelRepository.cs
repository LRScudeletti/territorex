using Dapper;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Repositories;

public static class AreaImovelRepository
{
    public static IReadOnlyList<AreaImovel> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      ImovelId,
                                      TipoImovelId,
                                      SituacaoImovelId,
                                      Condicao,
                                      AreaHectare,
                                      AreaHectareFiscal,
                                      Shape
                                 FROM AreaImovel;";

        return (IReadOnlyList<AreaImovel>)sqlConnection.Query<AreaImovel>(query);
    }

    public static IReadOnlyList<AreaImovel> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      ImovelId,
                                      TipoImovelId,
                                      SituacaoImovelId,
                                      Condicao,
                                      AreaHectare,
                                      AreaHectareFiscal,
                                      Shape
                                 FROM AreaImovel
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<AreaImovel>)sqlConnection.Query<AreaImovel>(query, new { territorioId });
    }

    public static IReadOnlyList<AreaImovel> RecuperarPorImovelId(string imovelId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      ImovelId,
                                      TipoImovelId,
                                      SituacaoImovelId,
                                      Condicao,
                                      AreaHectare,
                                      AreaHectareFiscal,
                                      Shape
                                 FROM AreaImovel
                                WHERE ImovelId = @imovelId;";

        return (IReadOnlyList<AreaImovel>)sqlConnection.Query<AreaImovel>(query, new { imovelId });
    }

    public static IReadOnlyList<AreaImovel> RecuperarPorTipoImovelId(int tipoImovelId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      ImovelId,
                                      TipoImovelId,
                                      SituacaoImovelId,
                                      Condicao,
                                      AreaHectare,
                                      AreaHectareFiscal,
                                      Shape
                                 FROM AreaImovel
                                WHERE TipoImovelId = @tipoImovelId;";

        return (IReadOnlyList<AreaImovel>)sqlConnection.Query<AreaImovel>(query, new { tipoImovelId });
    }

    public static IReadOnlyList<AreaImovel> RecuperarPorSituacaoImovelId(int situacaoImovelId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      ImovelId,
                                      TipoImovelId,
                                      SituacaoImovelId,
                                      Condicao,
                                      AreaHectare,
                                      AreaHectareFiscal,
                                      Shape
                                 FROM AreaImovel
                                WHERE SituacaoImovelId = @situacaoImovelId;";

        return (IReadOnlyList<AreaImovel>)sqlConnection.Query<AreaImovel>(query, new { situacaoImovelId });
    }
}