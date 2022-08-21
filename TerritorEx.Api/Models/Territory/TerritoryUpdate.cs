using System.ComponentModel.DataAnnotations;

namespace TerritorEx.Api.Models.Territory;

public class TerritoryUpdate
{
    [Required]
    public int TerritoryId { get; set; }

    public string TerritoryName { get; set; }

    public int TerritoryParentId { get; set; }

    public int LevelId { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public byte[] Shape { get; set; }

    [Required]
    public string UpdateUser { get; set; }

    [Required]
    public DateTime UpdateDate { get; set; } = DateTime.Now;
}