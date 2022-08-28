namespace TerritorEx.Api.Models;

public class TerritoryModel
{
    public int TerritoryId { get; set; }

    public string TerritoryName { get; set; }

    public int TerritoryParentId { get; set; }

    public int LevelId { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public byte[] Shape { get; set; }

    public string UpdateUser { get; set; }

    public DateTime UpdateDate { get; set; }
}