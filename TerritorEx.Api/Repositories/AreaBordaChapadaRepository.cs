﻿using Dapper;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Repositories;

public static class AreaBordaChapadaRepository
{
    public static IReadOnlyList<Area> RecuperarTodos()
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaBordaChapada;";

        return (IReadOnlyList<Area>)sqlConnection.Query<Area>(query);
    }

    public static IReadOnlyList<Area> RecuperarPorTerritorioId(int territorioId)
    {
        using var sqlConnection = Utils.RecuperarConexao();

        const string query = @"SELECT AreaId,
                                      TerritorioId,
                                      SicarId,
                                      Descricao,
                                      AreaHectare,
                                      Shape
                                 FROM AreaBordaChapada
                                WHERE TerritorioId = @territorioId;";

        return (IReadOnlyList<Area>)sqlConnection.Query<Area>(query, new { territorioId });
    }
}