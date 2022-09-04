using System.Text.Json.Serialization;

namespace TerritorEx.Api.Models.Territory;

public class Territory
{
    public int TerritoryId { get; set; }

    public string TerritoryName { get; set; }

    public int TerritoryParentId { get; set; }

    public int LevelId { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public byte[] Shape { get; set; }

    [JsonIgnore]
    public string UpdateUser { get; set; }

    [JsonIgnore]
    public DateTime UpdateDate { get; set; }
}