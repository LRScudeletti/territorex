using Dapper.Contrib.Extensions;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TerritorEx.Api.Entities;

[Description("schema_situacao_imovel")]
public class SituacaoImovel
{
    [Key]
    [Description("schema_situacao_imovel_id")]
    public int SituacaoImovelId { get; set; }

    [Description("schema_sigla_situacao")]
    public string Sigla { get; set; }

    [Description("schema_descricao_situacao")]
    public string Descricao { get; set; }

    [JsonIgnore]
    [Description("schema_usuario_atualizacao")]
    public string UsuarioAtualizacao { get; set; }

    [JsonIgnore]
    [Description("schema_data_atualizacao")]
    public DateTime DataAtualizacao { get; set; }
}

