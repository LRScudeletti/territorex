using Dapper.Contrib.Extensions;

namespace TerritorEx.Api.Models;

public class Territorio
{
    [Key]
    public int TerritorioId { get; set; }

    public string TerritorioNome { get; set; }

    public int TerritorioSuperiorId { get; set; }

    public int NivelTerritorioId { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public byte[] Shape { get; set; }
}