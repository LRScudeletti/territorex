using System.Reflection;
using DbUp;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Models.Enums;

namespace TerritorEx.Api.Configurations;

public static class DbUpConfiguration
{
    public static bool AtualizarBancoDados()
    {
        var upgrader =
            DeployChanges.To
                .SqlDatabase(Connection.ConnectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), s => s.Contains("Scripts"))
                .LogToConsole()
                .Build();

        var result = upgrader.PerformUpgrade();

        if (result.Successful) return true;

        Utils.CriarLog(TipoLog.Error, result.ToString(), true);
        return false;
    }
}
