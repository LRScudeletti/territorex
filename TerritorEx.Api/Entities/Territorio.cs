using Dapper.Contrib.Extensions;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TerritorEx.Api.Entities;

[Description("schema_territorio")]
public class Territorio
{
    [Key]
    [Description("schema_territorio_id")]
    public int TerritorioId { get; set; }

    [Description("schema_territorio_nome")]
    public string TerritorioNome { get; set; }

    [Description("schema_territorio_superior_id")]
    public int TerritorioSuperiorId { get; set; }

    [Description("schema_nivel_territorio_id")]
    public int NivelTerritorioId { get; set; }

    [Description("schema_latitude")]
    public double Latitude { get; set; }

    [Description("schema_longitude")]
    public double Longitude { get; set; }

    [Description("schema_shape")]
    public byte[] Shape { get; set; }

    [JsonIgnore]
    [Description("schema_usuario_atualizacao")]
    public string UsuarioAtualizacao { get; set; }

    [JsonIgnore]
    [Description("schema_data_atualizacao")]
    public DateTime DataAtualizacao { get; set; }
}