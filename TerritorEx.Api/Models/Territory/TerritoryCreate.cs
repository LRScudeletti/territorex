using System.ComponentModel.DataAnnotations;

namespace TerritorEx.Api.Models.Territory;

public class TerritoryCreate
{
    [Required]
    public int TerritoryId { get; set; }

    [Required]
    public string TerritoryName { get; set; }

    [Required]
    public int TerritoryParentId { get; set; }

    [Required]
    public int LevelId { get; set; }

    [Required]
    public double Latitude { get; set; }

    [Required]
    public double Longitude { get; set; }

    [Required]
    public byte[] Shape { get; set; }

    [Required]
    public string UpdateUser { get; set; }

    [Required]
    public DateTime UpdateDate { get; set; } = DateTime.Now;
}