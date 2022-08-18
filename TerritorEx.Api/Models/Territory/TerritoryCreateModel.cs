namespace TerritorEx.Api.Models.Territory;

using System.ComponentModel.DataAnnotations;

public class TerritoryCreateModel
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
}