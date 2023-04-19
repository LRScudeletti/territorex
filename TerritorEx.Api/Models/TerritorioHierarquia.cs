using System.ComponentModel;

namespace TerritorEx.Api.Models;

[Description("schema_territorio_hierarquia")]
public class TerritorioHierarquia
{
    [Description("schema_territorio_id")]
    public int TerritorioId { get; set; }

    [Description("schema_territorio_nome")]
    public string TerritorioNome { get; set; }

    [Description("schema_microrregiao_id")]
    public int MicrorregiaoId { get; set; }

    [Description("schema_microrregiao_nome")]
    public string MicrorregiaoNome { get; set; }

    [Description("schema_mesorregiao_id")]
    public int MesoregiaoId { get; set; }

    [Description("schema_mesorregiao_nome")]
    public string MesoregiaoNome { get; set; }

    [Description("schema_unidade_federativa_id")]
    public int UnidadeFederativaId { get; set; }

    [Description("schema_unidade_federativa_nome")]
    public string UnidadeFederativaNome { get; set; }

    [Description("schema_regiao_id")]
    public int RegiaoId { get; set; }

    [Description("schema_regiao_nome")]
    public string RegiaoNome { get; set; }

    [Description("schema_federacao_id")]
    public int FederacaoId { get; set; }

    [Description("schema_federacao_nome")]
    public string FederacaoNome { get; set; }
}