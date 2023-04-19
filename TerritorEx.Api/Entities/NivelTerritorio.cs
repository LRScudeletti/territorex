using Dapper.Contrib.Extensions;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TerritorEx.Api.Entities;

[Description("schema_nivel_territorio")]
public class NivelTerritorio
{
    [Key]
    [Description("schema_nivel_territorio_id")]
    public int NivelTerritorioId { get; set; }

    [Description("schema_sigla_nivel")]
    public string Sigla { get; set; }

    [Description("schema_descricao_nivel")]
    public string Descricao { get; set; }

    [JsonIgnore]
    [Description("schema_usuario_atualizacao")]
    public string UsuarioAtualizacao { get; set; }

    [JsonIgnore]
    [Description("schema_data_atualizacao")]
    public DateTime DataAtualizacao { get; set; }
}