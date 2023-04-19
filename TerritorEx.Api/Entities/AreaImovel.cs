using Dapper.Contrib.Extensions;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TerritorEx.Api.Entities;

[Description("schema_area_imovel")]
public class AreaImovel
{
    [Key]
    [Description("schema_area_id")]
    public int AreaId { get; set; }

    [Description("schema_territorio_id")]
    public int TerritorioId { get; set; }

    [Description("schema_imovel_id")]
    public string ImovelId { get; set; }

    [Description("schema_tipo_imovel_id")]
    public int TipoImovelId { get; set; }

    [Description("schema_situacao_imovel_id")]
    public int SituacaoImovelId { get; set; }

    [Description("schema_condicao")]
    public string Condicao { get; set; }

    [Description("schema_area_hectare")]
    public double AreaHectare { get; set; }

    [Description("schema_modulo_fiscal")]
    public double ModuloFiscal { get; set; }

    [Description("schema_shape")]
    public byte[] Shape { get; set; }

    [JsonIgnore]
    [Description("schema_usuario_atualizacao")]
    public string UsuarioAtualizacao { get; set; }

    [JsonIgnore]
    [Description("schema_data_atualizacao")]
    public DateTime DataAtualizacao { get; set; }
}