using Dapper.Contrib.Extensions;
using System.Text.Json.Serialization;

namespace TerritorEx.Api.Entities;

public class AreaImovel
{
    [Key]
    public int AreaId { get; set; }

    public int TerritorioId { get; set; }

    public string ImovelId { get; set; }

    public int TipoImovelId { get; set; }

    public int SituacaoImovelId { get; set; }

    public string Condicao { get; set; }

    public double AreaHectare { get; set; }

    public double ModuloFiscal { get; set; }

    public byte[] Shape { get; set; }

    [JsonIgnore]
    public string UsuarioAtualizacao { get; set; }

    [JsonIgnore]
    public DateTime DataAtualizacao { get; set; }
}