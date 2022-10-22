using Dapper.Contrib.Extensions;

namespace TerritorEx.Api.Models.AreaTerritorial;

public class Territorio
{
    [Key]
    public int TerritorioId { get; set; }

    public string TerritorioNome { get; set; }

    public int TerritorioPaiId { get; set; }

    public int NivelTerritorioId { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public byte[] Shape { get; set; }
}