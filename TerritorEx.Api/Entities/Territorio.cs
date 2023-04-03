using Dapper.Contrib.Extensions;
using System.Text.Json.Serialization;

namespace TerritorEx.Api.Entities;

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

    [JsonIgnore]
    public string UsuarioAtualizacao { get; set; }

    [JsonIgnore]
    public DateTime DataAtualizacao { get; set; }
}