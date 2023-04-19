using Dapper.Contrib.Extensions;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TerritorEx.Api.Entities;

[Description("schema_tipo_imovel")]
public class TipoImovel
{
    [Key]
    [Description("schema_tipo_imovel_id")]
    public int TipoImovelId { get; set; }

    [Description("schema_sigla_tipo")]
    public string Sigla { get; set; }

    [Description("schema_descricao_tipo")]
    public string Descricao { get; set; }

    [JsonIgnore]
    [Description("schema_usuario_atualizacao")]
    public string UsuarioAtualizacao { get; set; }

    [JsonIgnore]
    [Description("schema_data_atualizacao")]
    public DateTime DataAtualizacao { get; set; }
}

