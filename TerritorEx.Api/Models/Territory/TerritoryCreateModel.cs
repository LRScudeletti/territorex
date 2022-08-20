using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TerritorEx.Api.Models.Territory;

public class TerritoryCreateModel
{
    [Required]
    public int TerritoryId { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string TerritoryName { get; set; }

    [Required]
    public int TerritoryParentId { get; set; }

    [Required]
    public int LevelId { get; set; }

    [Required]
    [Column(TypeName = "double(38,18)")]
    public double Latitude { get; set; }

    [Required]
    [Column(TypeName = "double(38,18)")]
    public double Longitude { get; set; }

    [Required]
    public byte[] Shape { get; set; }
}