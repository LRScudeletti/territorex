using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TerritorEx.Api.Entities;

public class AreaConsolidada
{
    [Key]
    public int AreaId { get; set; }

    public int TerritorioId { get; set; }

    public int SicarId { get; set; }

    public string Descricao { get; set; }

    public double AreaHectare { get; set; }

    public byte[] Shape { get; set; }

    [JsonIgnore]
    public string UsuarioAtualizacao { get; set; }

    [JsonIgnore]
    public DateTime DataAtualizacao { get; set; }
}