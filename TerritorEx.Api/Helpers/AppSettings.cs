namespace TerritorEx.Api.Helpers;

public class AppSettings
{
    public string Secret { get; set; }

    // Atualiza o tempo de vida do token (em dias), os tokens inativos são
    // excluídos automaticamente do banco de dados após esse período.
    public int RefreshTokenTempoVida { get; set; }
}