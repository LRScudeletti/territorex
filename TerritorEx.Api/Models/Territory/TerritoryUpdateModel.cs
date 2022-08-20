using System.ComponentModel.DataAnnotations.Schema;

namespace TerritorEx.Api.Models.Territory;

public class TerritoryUpdateModel
{
    public int TerritoryId { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string TerritoryName { get; set; }

    public int TerritoryParentId { get; set; }

    public int LevelId { get; set; }

    [Column(TypeName = "double(38,18)")]
    public double Latitude { get; set; }

    [Column(TypeName = "double(38,18)")]
    public double Longitude { get; set; }

    public byte[] Shape { get; set; }
}