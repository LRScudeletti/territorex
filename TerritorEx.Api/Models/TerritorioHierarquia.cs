namespace TerritorEx.Api.Models;

public class TerritorioHierarquia
{
    public int TerritorioId { get; set; }

    public string TerritorioNome { get; set; }

    public int MicroregiaoId { get; set; }

    public string MicroregiaoNome { get; set; }

    public int MesoregiaoId { get; set; }

    public string MesoregiaoNome { get; set; }

    public int UnidadeFederativaId { get; set; }

    public string UnidadeFederativaNome { get; set; }

    public int RegiaoId { get; set; }

    public string RegiaoNome { get; set; }

    public int FederacaoId { get; set; }

    public string FederacaoNome { get; set; }
}